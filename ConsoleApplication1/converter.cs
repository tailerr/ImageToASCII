using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ConsoleApplication1
{
    class converter
    {
        Bitmap bitmap;
        string alphabet; 
        string path;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="f">path to image you want to convert</param>
        /// <param name="alp">alphabet of ASCII symbols ordered from 'white' to 'black'</param>
        /// <param name="Path">path where program will save output</param>
        /// <param name="k">compression parametr defined in (0, 1] (1=full size)</param>
        public converter(string f, string Path, double k, string alp = " .,:;ox%#@")
        {
            bitmap = new Bitmap(f);
            alphabet = alp;
            path = Path;
            if (k != 1)
            {
                bitmap = ResizeImage(bitmap, Convert.ToInt16(bitmap.Width * k), Convert.ToInt16(bitmap.Width * k));
            }
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipY);
        }

        /// <summary>
        /// Resize the image if needs
        /// </summary>
        /// <param name="image">bitmap to resize</param>
        /// <param name="width">new width of image</param>
        /// <param name="height">new height of image</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        /// <summary>
        /// The procces of convertation
        /// </summary>
        /// <param name="path">path where program will save output</param>
        public void procces(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color c = bitmap.GetPixel(i, j);
                        sw.Write(colorconv(c));
                    }
                    sw.WriteLine();
                }
            }
        }
     
        /// <summary>
        /// Convertaion color to our ASCII alphabet  
        /// </summary>
        /// <param name="c">color</param>
        /// <returns></returns>
        public char colorconv(Color c)
        {
            double res = (c.B + c.R + c.G)/3.0/256;
            double step = 1.0 / this.alphabet.Length;
            int r = Convert.ToInt16(Math.Truncate(res / step));
            return this.alphabet[alphabet.Length-1-r];
        }
    }
}
