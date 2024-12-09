using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace GK1_ColorCorrection
{
    public partial class Form1 : Form
    {
        Cursor eyedropCursor = new Cursor(Win32.LoadCursorFromFile("Resources\\eyedropper.cur"));
        bool isWhiteBalance = false;
        bool isBlackBalance = false;
        string currentFile = @"Images\Lenna.png";
        Histogram? histogram;

        public Form1()
        {
            InitializeComponent();
            pBlackReference.BackColor = Color.Black;
            pWhiteReference.BackColor = Color.White;

            InitHistograms();
            if (File.Exists(currentFile))
                LoadImage(currentFile);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Images");
            ofd.Title = "Open Image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFile = ofd.FileName;
                LoadImage(currentFile);
            }
        }

        public Color? GetColor(PictureBox pbox, Point p)
        {
            if (pbox.Image != null)
            {
                PropertyInfo? imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);
                Color? color = null;
                switch (pbox.SizeMode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        {
                            color = ((Bitmap)pbox.Image).GetPixel(p.X, p.Y);
                            break;
                        }
                    case PictureBoxSizeMode.CenterImage:
                    case PictureBoxSizeMode.StretchImage:
                    case PictureBoxSizeMode.Zoom:
                        {
                            if (imageRectangleProperty == null)
                                break;

                            Rectangle? rectangle = (Rectangle?)imageRectangleProperty.GetValue(pbox, null);
                            if (rectangle != null && rectangle.Value.Contains(p))
                            {
                                using (Bitmap copy = new Bitmap(pbox.ClientSize.Width, pbox.ClientSize.Height))
                                {
                                    using (Graphics g = Graphics.FromImage(copy))
                                    {
                                        g.DrawImage(pbox.Image, rectangle.Value);

                                        color = copy.GetPixel(p.X, p.Y);
                                    }
                                }
                            }
                            break;
                        }
                }

                return color;
            }

            return null;
        }

        public bool ContainsInImage(PictureBox pbox, Point p)
        {
            if (pbox.Image != null)
            {
                PropertyInfo? imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);

                switch (pbox.SizeMode)
                {
                    case PictureBoxSizeMode.Normal:
                    case PictureBoxSizeMode.AutoSize:
                        return true;
                    case PictureBoxSizeMode.CenterImage:
                    case PictureBoxSizeMode.StretchImage:
                    case PictureBoxSizeMode.Zoom:
                        {
                            if (imageRectangleProperty == null)
                                throw new ArgumentNullException();

                            Rectangle? rectangle = (Rectangle?)imageRectangleProperty.GetValue(pbox, null);
                            if (rectangle != null)
                                return rectangle.Value.Contains(p);

                            break;
                        }
                }

                return false;
            }

            return false;
        }

        private void pbPreview_Click(object sender, EventArgs e)
        {
            if (isWhiteBalance || isBlackBalance)
            {
                if (((MouseEventArgs)e).Button == MouseButtons.Left)
                {
                    Color? color = GetColor((PictureBox)sender, ((MouseEventArgs)e).Location);

                    if (color != null)
                    {
                        if (isWhiteBalance)
                        {
                            isWhiteBalance = false;
                            pWhiteReference.BackColor = color.Value;
                        }
                        else if (isBlackBalance)
                        {
                            isBlackBalance = false;
                            pBlackReference.BackColor = color.Value;
                        }

                        Cursor = Cursors.Default;
                    }
                }
                else if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    isWhiteBalance = false;
                    isBlackBalance = false;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void pbPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (isWhiteBalance || isBlackBalance)
            {
                if (!ContainsInImage((PictureBox)sender, e.Location))
                    Cursor = Cursors.Default;
                else
                    Cursor = eyedropCursor;
            }
        }

        private void pbPreview_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void bWhiteBalance_Click(object sender, EventArgs e)
        {
            if (histogram == null) return;
            isWhiteBalance = true;
            isBlackBalance = false;
        }

        private void bBlackBalance_Click(object sender, EventArgs e)
        {
            if (histogram == null) return;
            isWhiteBalance = false;
            isBlackBalance = true;
        }

        private void bGreyscale_Click(object sender, EventArgs e)
        {
            if (histogram == null) return;

            Bitmap bmp = (Bitmap)(pbPreview.Image);

            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        byte red = ptr[j * data.Stride + 3 * i + 2];
                        byte green = ptr[j * data.Stride + 3 * i + 1];
                        byte blue = ptr[j * data.Stride + 3 * i];

                        byte gray = (byte)Math.Ceiling(0.299 * red + 0.587 * green + 0.114 * blue);

                        ptr[j * data.Stride + 3 * i + 2] = gray;
                        ptr[j * data.Stride + 3 * i + 1] = gray;
                        ptr[j * data.Stride + 3 * i] = gray;
                    }
                }
                bmp.UnlockBits(data);
            }

            RefreshHistograms();
            pbPreview.Invalidate();
        }

        private void bHistEqualization_Click(object sender, EventArgs e)
        {
            if (histogram == null) return;
            byte[][] IValues = new byte[3][];
            double[] Dmin = new double[3];
            Dmin[0] = histogram.CFDValues[0].Where(x => x > 0).Min();
            Dmin[1] = histogram.CFDValues[1].Where(x => x > 0).Min();
            Dmin[2] = histogram.CFDValues[2].Where(x => x > 0).Min();

            for (int i = 0; i < 3; i++)
            {
                IValues[i] = new byte[256];
                for (int j = 0; j < 256; j++)
                {
                    IValues[i][j] = (byte)Math.Ceiling((histogram.CFDValues[i][j] - Dmin[i]) / (1 - Dmin[i]) * 255);
                }
            }

            Bitmap bmp = (Bitmap)(pbPreview.Image);

            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        byte red = ptr[j * data.Stride + 3 * i + 2];
                        byte green = ptr[j * data.Stride + 3 * i + 1];
                        byte blue = ptr[j * data.Stride + 3 * i];

                        red = IValues[0][red];
                        green = IValues[1][green];
                        blue = IValues[2][blue];

                        ptr[j * data.Stride + 3 * i + 2] = red;
                        ptr[j * data.Stride + 3 * i + 1] = green;
                        ptr[j * data.Stride + 3 * i] = blue;
                    }
                }
                bmp.UnlockBits(data);
            }

            RefreshHistograms();
            pbPreview.Invalidate();
        }

        private void bApplyBalance_Click(object sender, EventArgs e)
        {
            ImageBalance(pWhiteReference.BackColor, pBlackReference.BackColor);
            pBlackReference.BackColor = Color.Black;
            pWhiteReference.BackColor = Color.White;
        }

        private void ImageBalance(Color whiteReference, Color blackReference)
        {
            static byte ColorScale(byte color, byte white, byte black)
            {
                if (white == black) return color;
                return (byte)Math.Clamp(Math.Ceiling((double)(color - black) / (white - black) * 255), 0, 255);
            }

            if (histogram == null) return;

            Bitmap bmp = (Bitmap)(pbPreview.Image);

            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        byte red = ptr[j * data.Stride + 3 * i + 2];
                        byte green = ptr[j * data.Stride + 3 * i + 1];
                        byte blue = ptr[j * data.Stride + 3 * i];

                        red = ColorScale(red, whiteReference.R, blackReference.R);
                        green = ColorScale(green, whiteReference.G, blackReference.G);
                        blue = ColorScale(blue, whiteReference.B, blackReference.B);

                        ptr[j * data.Stride + 3 * i + 2] = red;
                        ptr[j * data.Stride + 3 * i + 1] = green;
                        ptr[j * data.Stride + 3 * i] = blue;
                    }
                }
                bmp.UnlockBits(data);
            }

            RefreshHistograms();
            pbPreview.Invalidate();
        }

        private void HistStretching_Click(object sender, EventArgs e)
        {
            static byte Strech(byte color, byte Imax, byte Imin)
            {
                if (Imax == Imin) return color;
                return (byte)Math.Clamp(Math.Ceiling((double)(color - Imin) / (Imax - Imin) * 255), 0, 255);
            }

            if (histogram == null) return;
            byte[] Imin = new byte[3];
            byte[] Imax = new byte[3];
            int[] max = [histogram.Values[0].Max(), histogram.Values[1].Max(), histogram.Values[2].Max()];
            for (int i = 0; i < 3; i++)
            {
                for (byte j = 0; j <= 255; j++)
                {
                    if (histogram.Values[i][j] > max[i] * (double)nudStretchingThreshold.Value)
                    {
                        Imin[i] = j;
                        break;
                    }
                }

                for (byte j = 255; j >= 0; j--)
                {
                    if (histogram.Values[i][j] > max[i] * (double)nudStretchingThreshold.Value)
                    {
                        Imax[i] = j;
                        break;
                    }
                }
            }

            Bitmap bmp = (Bitmap)(pbPreview.Image);

            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    for (int i = 0; i < bmp.Width; i++)
                    {
                        byte red = ptr[j * data.Stride + 3 * i + 2];
                        byte green = ptr[j * data.Stride + 3 * i + 1];
                        byte blue = ptr[j * data.Stride + 3 * i];

                        red = Strech(red, Imax[0], Imin[0]);
                        green = Strech(green, Imax[1], Imin[1]);
                        blue = Strech(blue, Imax[2], Imin[2]);

                        ptr[j * data.Stride + 3 * i + 2] = red;
                        ptr[j * data.Stride + 3 * i + 1] = green;
                        ptr[j * data.Stride + 3 * i] = blue;
                    }
                }
                bmp.UnlockBits(data);
            }

            RefreshHistograms();
            pbPreview.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (histogram == null) return;
            pbPreview.Image.Save(currentFile);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            saveFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Images");
            saveFileDialog.Title = "Save Image As";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (histogram == null) return;
                pbPreview.Image.Save(saveFileDialog.FileName);
            }
        }

        private void LoadImage(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            Stream s = new MemoryStream(data);
            pbPreview.Image = new Bitmap(s);
            histogram = new Histogram((Bitmap)pbPreview.Image);
            RefreshHistograms();
        }

        private void InitHistograms()
        {
            int width = tlpHistograms.GetColumnWidths()[0];
            int height = tlpHistograms.GetRowHeights()[0];

            PictureBox pictureBoxRed = new PictureBox();
            pictureBoxRed.Dock = DockStyle.Fill;
            pictureBoxRed.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRed.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxRed, 0, 0);

            PictureBox pictureBoxGreen = new PictureBox();
            pictureBoxGreen.Dock = DockStyle.Fill;
            pictureBoxGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGreen.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxGreen, 0, 1);

            PictureBox pictureBoxBlue = new PictureBox();
            pictureBoxBlue.Dock = DockStyle.Fill;
            pictureBoxBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBlue.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxBlue, 0, 2);

            PictureBox pictureBoxCDFRed = new PictureBox();
            pictureBoxCDFRed.Dock = DockStyle.Fill;
            pictureBoxCDFRed.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFRed.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFRed, 1, 0);

            PictureBox pictureBoxCDFGreen = new PictureBox();
            pictureBoxCDFGreen.Dock = DockStyle.Fill;
            pictureBoxCDFGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFGreen.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFGreen, 1, 1);

            PictureBox pictureBoxCDFBlue = new PictureBox();
            pictureBoxCDFBlue.Dock = DockStyle.Fill;
            pictureBoxCDFBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFBlue.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFBlue, 1, 2);
        }

        private void RefreshHistograms()
        {
            if (histogram == null) return;

            int width = tlpHistograms.GetColumnWidths()[0];
            int height = tlpHistograms.GetRowHeights()[0];
            histogram.CalcHistogram();

            ((PictureBox)tlpHistograms.GetControlFromPosition(0, 0)!).Image = histogram.GetHistogram(width, height, Channel.Red);
            ((PictureBox)tlpHistograms.GetControlFromPosition(0, 1)!).Image = histogram.GetHistogram(width, height, Channel.Green);
            ((PictureBox)tlpHistograms.GetControlFromPosition(0, 2)!).Image = histogram.GetHistogram(width, height, Channel.Blue);

            ((PictureBox)tlpHistograms.GetControlFromPosition(1, 0)!).Image = histogram.GetCDF(width, height, Channel.Red);
            ((PictureBox)tlpHistograms.GetControlFromPosition(1, 1)!).Image = histogram.GetCDF(width, height, Channel.Green);
            ((PictureBox)tlpHistograms.GetControlFromPosition(1, 2)!).Image = histogram.GetCDF(width, height, Channel.Blue);
        }

        private Bitmap CreateCheckerboard(int width, int height, int squareSize)
        {
            Bitmap bmp = new Bitmap(width, height);
            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if ((i / squareSize + j / squareSize) % 2 == 0)
                        {
                            ptr[j * data.Stride + 3 * i + 2] = 255;
                            ptr[j * data.Stride + 3 * i + 1] = 255;
                            ptr[j * data.Stride + 3 * i] = 255;
                        }
                        else
                        {
                            ptr[j * data.Stride + 3 * i + 2] = 0;
                            ptr[j * data.Stride + 3 * i + 1] = 0;
                            ptr[j * data.Stride + 3 * i] = 0;
                        }
                    }
                }

                bmp.UnlockBits(data);
            }
            return bmp;
        }
        private Bitmap CreateGradient(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Color color = HSVtoRGB((double)i / width * 360, 1 - ((double)j / height), 1);
                        ptr[j * data.Stride + 3 * i + 2] = color.R;
                        ptr[j * data.Stride + 3 * i + 1] = color.G;
                        ptr[j * data.Stride + 3 * i] = color.B;
                    }
                }

                bmp.UnlockBits(data);
            }
            return bmp;
        }

        private static Color HSVtoRGB(double h, double s, double v)
        {
            double c = v * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = v - c;

            double r = 0, g = 0, b = 0;
            if (h >= 0 && h < 60)
            {
                r = c;
                g = x;
            }
            else if (h >= 60 && h < 120)
            {
                r = x;
                g = c;
            }
            else if (h >= 120 && h < 180)
            {
                g = c;
                b = x;
            }
            else if (h >= 180 && h < 240)
            {
                g = x;
                b = c;
            }
            else if (h >= 240 && h < 300)
            {
                r = x;
                b = c;
            }
            else if (h >= 300 && h < 360)
            {
                r = c;
                b = x;
            }

            return Color.FromArgb((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDialog cd = new CreateDialog();
            cd.ImageWidth = pbPreview.Width;
            cd.ImageHeight = pbPreview.Height;
            cd.PatternSize = 50;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = CreateCheckerboard(cd.ImageWidth, cd.ImageHeight, cd.PatternSize);
                Bitmap gradient = CreateGradient(cd.ImageWidth/ 3, cd.ImageHeight / 3);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(gradient, new Rectangle(cd.ImageWidth / 3, cd.ImageHeight / 3, cd.ImageWidth / 3, cd.ImageHeight / 3));
                }

                pbPreview.Image = bmp;
                currentFile = @"Images\TestImage.png";

                histogram = new Histogram((Bitmap)pbPreview.Image);
                RefreshHistograms();
            }
        }
    }
}
