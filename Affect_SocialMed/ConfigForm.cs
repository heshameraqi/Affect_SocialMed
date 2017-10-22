using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VS_Affectiva
{
    public partial class ConfigForm : Form
    {
        Affdex.Detector detector = null;
        AffectivaSurface videoSurface = null;

        private bool initialized = false;

        public ConfigForm()
        {
            InitializeComponent();
            modeChecListkbox.SelectedIndex = 0;
            initialized = true;
        }

        /*private Affdex.Frame LoadFrameFromFile(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            int numBytes = bitmap.Width * bitmap.Height * 3;
            byte[] rgbValues = new byte[numBytes];

            int data_x = 0;
            int ptr_x = 0;
            int row_bytes = bitmap.Width * 3;

            // The bitmap requires bitmap data to be byte aligned.
            // http://stackoverflow.com/questions/20743134/converting-opencv-image-to-gdi-bitmap-doesnt-work-depends-on-image-size

            for (int y = 0; y < bitmap.Height; y++)
            {
                Marshal.Copy(ptr + ptr_x, rgbValues, data_x, row_bytes);//(pixels, data_x, ptr + ptr_x, row_bytes);
                data_x += row_bytes;
                ptr_x += bmpData.Stride;
            }

            bitmap.UnlockBits(bmpData);

            return new Affdex.Frame(bitmap.Width, bitmap.Height, rgbValues, Affdex.Frame.COLOR_FORMAT.BGR);
        }*/

        private void restart_mode()
        {
            if (initialized)
            {
                //if (videoSurface != null)
                //    videoSurface.Close();

                Affdex.FaceDetectorMode FaceDeteMode = largeFacesCheckBox.Checked ? Affdex.FaceDetectorMode.LARGE_FACES : Affdex.FaceDetectorMode.SMALL_FACES;
                if (modeChecListkbox.SelectedIndex == 0)
                    detector = new Affdex.CameraDetector((int)camIDNumericUpDown.Value, (double)camFPSNumericUpDown.Value, (double)camFPSNumericUpDown.Value, (uint)numFacesNumericUpDown.Value, FaceDeteMode);
                else if (modeChecListkbox.SelectedIndex == 1)
                    detector = new Affdex.PhotoDetector((uint)numFacesNumericUpDown.Value, FaceDeteMode);
                else if (modeChecListkbox.SelectedIndex == 2)
                    detector = new Affdex.VideoDetector(30, (uint)numFacesNumericUpDown.Value, FaceDeteMode);
                
                //detector.setClassifierPath("C:\\Program Files\\Affectiva\\AffdexSDK\\data");
                detector.setClassifierPath(Directory.GetCurrentDirectory() + "\\affectiva_SDK_data");
                detector.setDetectAllEmotions(true);
                detector.setDetectAllExpressions(false);
                detector.setDetectAllEmojis(false);
                detector.setDetectAllAppearances(false);
                detector.start();
                //System.Console.WriteLine("Face detector mode = " + detector.getFaceDetectorMode().ToString());
                //if (modeCheckbox.SelectedIndex == 2) ((Affdex.VideoDetector)detector).process(options.Input);
                //else if (modeCheckbox.SelectedIndex == 1) ((Affdex.PhotoDetector)detector).process(LoadFrameFromFile(options.Input));

                MainForm affForm = new MainForm(detector);
                affForm.Show();
                //detector.stop();
            }
        }

        // Configuration Change Events
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            restart_mode();
        }
        private void modeChecListkbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            restart_mode();
        }

        private void largeFacesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            restart_mode();
        }

        private void camIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            restart_mode();
        }

        private void camFPSNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            restart_mode();
        }

        private void numFacesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            restart_mode();
        }



    }
}
