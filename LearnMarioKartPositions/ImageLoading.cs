using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMarioKartPositions
{
    class ImageLoading
    {
        private static Random r = new Random();

        /// <summary>
        /// Loads an image based on the label and path received
        /// </summary>
        /// <param name="label">the number that is in the image, extra = 0</param>
        /// <param name="dataPath">the path to the folder where you can find the folders with numbers</param>
        /// <returns></returns>
        public static PositionData LoadImage(int label, string dataPath)
        {
            string path = dataPath + "\\" + (label == 0 ? "extra" : label.ToString());
            string[] filesInFolder = Directory.GetFiles(path);
            int fileIndex = r.Next(filesInFolder.Length);
            Bitmap image = (Bitmap)Image.FromFile(filesInFolder[fileIndex]);
            return new PositionData(image, label);
        }
    }
}
