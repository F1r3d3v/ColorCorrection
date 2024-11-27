using System.Drawing.Imaging;
using System.Threading.Channels;

namespace GK1_ColorCorrection
{
    public enum Channel
    {
        Red,
        Green,
        Blue
    }

    internal class Histogram
    {
        public int[][] Values { get; private set; }
        public double[][] CFDValues { get; private set; }
        private Bitmap _bmp;

        public Histogram(Bitmap bmp)
        {
            _bmp = bmp;
            CalcHistogram();
        }

        public void CalcHistogram()
        {
            Values = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                Values[i] = new int[256];
            }

            unsafe
            {
                var data = _bmp.LockBits(new Rectangle(0, 0, _bmp.Width, _bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int i = 0; i < _bmp.Width; i++)
                {
                    for (int j = 0; j < _bmp.Height; j++)
                    {
                        byte value = ptr[j * data.Stride + 3 * i + 2];
                        Values[0][value]++;
                        value = ptr[j * data.Stride + 3 * i + 1];
                        Values[1][value]++;
                        value = ptr[j * data.Stride + 3 * i];
                        Values[2][value]++;
                    }
                }
                _bmp.UnlockBits(data);
            }

            CFDValues = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                CFDValues[i] = new double[256];
                CFDValues[i][0] = Values[i][0];
                for (int j = 1; j < 256; j++)
                    CFDValues[i][j] = CFDValues[i][j - 1] + Values[i][j];

                for (int j = 0; j < 256; j++)
                    CFDValues[i][j] /= _bmp.Width * _bmp.Height;
            }
        }
        public Bitmap GetHistogram(int width, int height, Channel channel)
        {
            int max = Values[(int)channel].Max();
            Bitmap histogram = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Color color = channel switch
            {
                Channel.Red => Color.FromArgb(255, 0, 0),
                Channel.Green => Color.FromArgb(0, 255, 0),
                Channel.Blue => Color.FromArgb(0, 0, 255),
                _ => throw new ArgumentOutOfRangeException()
            };

            unsafe
            {
                var data = histogram.LockBits(new Rectangle(0, 0, histogram.Width, histogram.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                int* ptr = (int*)data.Scan0;

                for (int i = 0; i < width; i++)
                {
                    byte ind = (byte)Math.Ceiling(i * 255.0 / width);
                    int h = (int)Math.Ceiling((double)Values[(int)channel][ind] / max * height);
                    for (int j = 0; j < h; j++)
                    {
                        ptr[(histogram.Height - j - 1) * width + i] = color.ToArgb();
                    }
                }
                histogram.UnlockBits(data);
            }

            return histogram;
        }

        public Bitmap GetCDF(int width, int height, Channel channel)
        {
            Bitmap histogram = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Color color = channel switch
            {
                Channel.Red => Color.FromArgb(255, 0, 0),
                Channel.Green => Color.FromArgb(0, 255, 0),
                Channel.Blue => Color.FromArgb(0, 0, 255),
                _ => throw new ArgumentOutOfRangeException()
            };

            unsafe
            {
                var data = histogram.LockBits(new Rectangle(0, 0, histogram.Width, histogram.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                int* ptr = (int*)data.Scan0;

                for (int i = 0; i < width; i++)
                {
                    byte ind = (byte)Math.Ceiling(i * 255.0 / width);
                    int h = (int)Math.Ceiling(CFDValues[(int)channel][ind] * height);
                    for (int j = 0; j < h; j++)
                    {
                        ptr[(histogram.Height - j - 1) * width + i] = color.ToArgb();
                    }
                }
                histogram.UnlockBits(data);
            }

            return histogram;
        }
    }
}
