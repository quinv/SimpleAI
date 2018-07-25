using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioKartPositionChecker
{
    public partial class MarioKartPositionForm : Form
    {
        private int x = 800;
        private int y = 800;
        private int width = 200;
        private int height = 200;

        public MarioKartPositionForm()
        {
            InitializeComponent();
            PositionTexbox.KeyUp += PositionTexbox_KeyPress;
            UpdateScreenCoordinates();
            Thread updateImageThread = new Thread(() => UpdateCaptureImage());
            updateImageThread.Start();
        }

        private void PositionTexbox_KeyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                UpdateScreenCoordinates();
            }
        }

        private void UpdateScreenCoordinates()
        {
            var coordinates = PositionTexbox.Text.Split(';');
            try
            {
                x = int.Parse(coordinates[0]);
                y = int.Parse(coordinates[1]);
                width = int.Parse(coordinates[2]);
                height = int.Parse(coordinates[3]);
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateCaptureImage()
        {
            DateTime lastImageTime = DateTime.Now;
            for (; ; )
            {
                if (!PositionImagePanel.IsDisposed)
                {
                    Bitmap screenCap = ImageHandling.CaptureFromScreen(x, y, width, height);
                    Graphics g = PositionImagePanel.CreateGraphics();
                    Bitmap scaledImage = new Bitmap(20, 20);
                    Graphics destinationGraphics = Graphics.FromImage(scaledImage);
                    destinationGraphics.DrawImage(screenCap, new Rectangle(new Point(), scaledImage.Size));

                    Bitmap grayScaleImage = ImageHandling.MakeGrayscale(scaledImage);
                    g.DrawImage(grayScaleImage, PositionImagePanel.DisplayRectangle);
                    Thread.Sleep(80);
                    try
                    {
                        if (lastImageTime.AddSeconds(int.Parse(TextBoxTime.Text)) < DateTime.Now && CheckBoxSaveImage.Checked)
                        {
                            lastImageTime = DateTime.Now;
                            ImageHandling.SaveImage(grayScaleImage, "D:\\neural networks\\NeuralNetworkLib\\TrainingData\\PositionData\\");
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void PositionText_Enter(object sender, EventArgs e)
        {

        }
    }
}
