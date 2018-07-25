using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioKartPositionChecker
{
    class ImageHandling
    {
        public static Bitmap CaptureFromScreen(int x, int y, int width, int height)
        {
            Bitmap bmpScreenCapture = null;
            Rectangle rect = new Rectangle(x, y, width, height);

            bmpScreenCapture = new Bitmap(rect.Width, rect.Height);

            Graphics p = Graphics.FromImage(bmpScreenCapture);
            p.CopyFromScreen(rect.X,
                     rect.Y,
                     0, 0,
                     rect.Size,
                     CopyPixelOperation.SourceCopy);

            return bmpScreenCapture;
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public static void SaveImage(Bitmap imageToSave, string saveLocation)
        {
            imageToSave.Save(saveLocation + DateTime.Now.Ticks + ".bmp");
        }
    }
}
