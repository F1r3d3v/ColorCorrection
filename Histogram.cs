using System.Drawing.Imaging;

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

        public Histogram(Bitmap bmp)
        {
            int[][] values = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                values[i] = new int[256];
            }

            unsafe
            {
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                byte* ptr = (byte*)data.Scan0;
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        byte value = ptr[j * data.Stride + 3 * i + 2];
                        values[0][value]++;
                        value = ptr[j * data.Stride + 3 * i + 1];
                        values[1][value]++;
                        value = ptr[j * data.Stride + 3 * i];
                        values[2][value]++;
                    }
                }
                bmp.UnlockBits(data);
            }

            Values = values;
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
                    byte ind = (byte)(i * 255 / width);
                    int h = (int)((double)Values[(int)channel][ind] / max * height);
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
            int max = Values[(int)channel].Max();
            Bitmap histogram = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Color color = channel switch
            {
                Channel.Red => Color.FromArgb(255, 0, 0),
                Channel.Green => Color.FromArgb(0, 255, 0),
                Channel.Blue => Color.FromArgb(0, 0, 255),
                _ => throw new ArgumentOutOfRangeException()
            };

            int[] cdf = new int[256];
            cdf[0] = Values[(int)channel][0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + Values[(int)channel][i];
            }

            unsafe
            {
                var data = histogram.LockBits(new Rectangle(0, 0, histogram.Width, histogram.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                int* ptr = (int*)data.Scan0;

                for (int i = 0; i < width; i++)
                {
                    byte ind = (byte)(i * 255 / width);
                    int h = (int)((double)cdf[ind] / cdf[255] * height);
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
