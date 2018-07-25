using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMarioKartPositions
{
    public struct PositionData
    {
        public Bitmap image;
        public int label;
        public float[] imageInfo;
        public float[] expectedResult;

        public PositionData(Bitmap image, int label)
        {
            this.image = image;
            this.label = label;

            imageInfo = new float[image.Width * image.Height];
            expectedResult = new float[13];

            ReadImageInfo();
            CreateResult();
        }

        private void ReadImageInfo()
        {
            int currentPixel = 0;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageInfo[currentPixel] = image.GetPixel(i, j).R / 255f;
                    currentPixel++;
                }
            }
        }

        private void CreateResult()
        {
            for (int i = 0; i < expectedResult.Length; i++)
            {
                if(i == label)
                {
                    expectedResult[i] = 1;
                }
                else
                {
                    expectedResult[i] = 0;
                }
            }
        }
    }
}
