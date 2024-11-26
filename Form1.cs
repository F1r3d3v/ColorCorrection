using System.Reflection;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GK1_ColorCorrection
{
    public partial class Form1 : Form
    {
        Cursor eyedropCursor = new Cursor(Win32.LoadCursorFromFile("Resources\\eyedropper.cur"));
        bool isWhiteBalance = false;
        bool isBlackBalance = false;

        public Form1()
        {
            InitializeComponent();
            pBlackReference.BackColor = Color.Black;
            pWhiteReference.BackColor = Color.White;

            int width = tlpHistograms.GetColumnWidths()[0];
            int height = tlpHistograms.GetRowHeights()[0];

            Histogram h = new Histogram(new Bitmap("Images\\Lenna.png"));

            PictureBox pictureBoxRed = new PictureBox();
            pictureBoxRed.Image = h.GetHistogram(width, height, Channel.Red);
            pictureBoxRed.Dock = DockStyle.Fill;
            pictureBoxRed.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRed.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxRed, 0, 0);

            PictureBox pictureBoxGreen = new PictureBox();
            pictureBoxGreen.Image = h.GetHistogram(width, height, Channel.Green);
            pictureBoxGreen.Dock = DockStyle.Fill;
            pictureBoxGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGreen.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxGreen, 0, 1);

            PictureBox pictureBoxBlue = new PictureBox();
            pictureBoxBlue.Image = h.GetHistogram(width, height, Channel.Blue);
            pictureBoxBlue.Dock = DockStyle.Fill;
            pictureBoxBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBlue.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxBlue, 0, 2);

            PictureBox pictureBoxCDFRed = new PictureBox();
            pictureBoxCDFRed.Image = h.GetCDF(width, height, Channel.Red);
            pictureBoxCDFRed.Dock = DockStyle.Fill;
            pictureBoxCDFRed.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFRed.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFRed, 1, 0);

            PictureBox pictureBoxCDFGreen = new PictureBox();
            pictureBoxCDFGreen.Image = h.GetCDF(width, height, Channel.Green);
            pictureBoxCDFGreen.Dock = DockStyle.Fill;
            pictureBoxCDFGreen.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFGreen.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFGreen, 1, 1);

            PictureBox pictureBoxCDFBlue = new PictureBox();
            pictureBoxCDFBlue.Image = h.GetCDF(width, height, Channel.Blue);
            pictureBoxCDFBlue.Dock = DockStyle.Fill;
            pictureBoxCDFBlue.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCDFBlue.Padding = new Padding(2);
            tlpHistograms.Controls.Add(pictureBoxCDFBlue, 1, 2);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "Images");
            ofd.Title = "Open Image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPreview.Image = new Bitmap(ofd.FileName);
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
            isWhiteBalance = true;
        }

        private void bBlackBalance_Click(object sender, EventArgs e)
        {
            isBlackBalance = true;
        }
    }
}
