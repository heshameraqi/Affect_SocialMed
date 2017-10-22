using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace VS_Affectiva
{
    public partial class AffectivaSurface : System.Windows.Forms.Panel, Affdex.ProcessStatusListener, Affdex.ImageListener
    {
        public float[] affectivaResult = new float[5];
        public float[] AffectivaResult
        {
            get { return affectivaResult; }
        }
        public event EventHandler ResultsChanged;

        public AffectivaSurface(Affdex.Detector detector)
        {
            detector.setImageListener(this);
            detector.setProcessStatusListener(this);
            //InitializeComponent();
            rwLock = new ReaderWriterLock();
            this.DoubleBuffered = true;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        public void onImageCapture(Affdex.Frame frame)
        {
            frame.Dispose();
        }

        public void onImageResults(Dictionary<int, Affdex.Face> faces, Affdex.Frame frame)
        {
            try
            {
                process_fps = 1.0f / (frame.getTimestamp() - process_last_timestamp);
                process_last_timestamp = frame.getTimestamp();
                //System.Console.WriteLine(" pfps: {0}", process_fps.ToString());

                byte[] pixels = frame.getBGRByteArray();
                this.img = new Bitmap(frame.getWidth(), frame.getHeight(), PixelFormat.Format24bppRgb);
                var bounds = new Rectangle(0, 0, frame.getWidth(), frame.getHeight());
                BitmapData bmpData = img.LockBits(bounds, ImageLockMode.WriteOnly, img.PixelFormat);
                IntPtr ptr = bmpData.Scan0;

                int data_x = 0;
                int ptr_x = 0;
                int row_bytes = frame.getWidth() * 3;

                // The bitmap requires bitmap data to be byte aligned.
                // http://stackoverflow.com/questions/20743134/converting-opencv-image-to-gdi-bitmap-doesnt-work-depends-on-image-size

                for (int y = 0; y < frame.getHeight(); y++)
                {
                    Marshal.Copy(pixels, data_x, ptr + ptr_x, row_bytes);
                    data_x += row_bytes;
                    ptr_x += bmpData.Stride;
                }
                img.UnlockBits(bmpData);

                this.faces = faces;
                //rwLock.ReleaseWriterLock();

                this.Invalidate();
                frame.Dispose();
            }
            catch { }
        }

        private void DrawResults(Graphics g, Dictionary<int, Affdex.Face> faces)
        {
            Pen whitePen = new Pen(Color.OrangeRed);
            //Pen redPen = new Pen(Color.DarkRed);
            Pen redPen = new Pen(Color.Red);
            Pen bluePen = new Pen(Color.DarkBlue);
            Font aFont = new Font(FontFamily.GenericSerif, 20, FontStyle.Bold);
            float radius = 2;
            int spacing = 30;
            int left_margin = 30;

            foreach (KeyValuePair<int, Affdex.Face> pair in faces)
            {
                Affdex.Face face = pair.Value;
                foreach (Affdex.FeaturePoint fp in face.FeaturePoints)
                {
                    g.DrawCircle(whitePen, fp.X, fp.Y, radius);
                }

                Affdex.FeaturePoint tl = minPoint(face.FeaturePoints);
                Affdex.FeaturePoint br = maxPoint(face.FeaturePoints);

                //// Trim results to be within screen
                //br.X = System.Math.Min( br.X , System.Math.Max(this.Size.Width  - 220, 0) );
                //br.Y = System.Math.Min( br.Y , System.Math.Max(this.Size.Height - 800, 0) );
                //
                //int padding = (int)tl.Y;
                //
                ////g.DrawString(String.Format("ID: {0}", pair.Key), aFont, whitePen.Brush, new PointF(br.X, padding += spacing));
                //
                ////g.DrawString("APPEARANCE", aFont, bluePen.Brush, new PointF(br.X, padding += (spacing * 2)));
                ////g.DrawString(face.Appearance.Gender.ToString(), aFont, whitePen.Brush, new PointF(br.X, padding += spacing));
                ////g.DrawString(face.Appearance.Age.ToString(), aFont, whitePen.Brush, new PointF(br.X, padding += spacing));
                ////g.DrawString(face.Appearance.Ethnicity.ToString(), aFont, whitePen.Brush, new PointF(br.X, padding += spacing));
                ////g.DrawString("Glasses: " + face.Appearance.Glasses.ToString(), aFont, whitePen.Brush, new PointF(br.X, padding += spacing));
                //
                ////g.DrawString("EMOJIs", aFont, bluePen.Brush, new PointF(br.X, padding += (spacing * 2)));
                ////g.DrawString("DominantEmoji: " + face.Emojis.dominantEmoji.ToString(), aFont,
                ////             (face.Emojis.dominantEmoji != Affdex.Emoji.Unknown) ? whitePen.Brush : redPen.Brush,
                ////             new PointF(br.X, padding += spacing));
                ////foreach (String emojiName in Enum.GetNames(typeof(Affdex.Emoji)))
                ////{
                ////    PropertyInfo prop = face.Emojis.GetType().GetProperty(emojiName.ToLower());
                ////    if (prop != null)
                ////    {
                ////        float value = (float)prop.GetValue(face.Emojis, null);
                ////        string c = String.Format("{0}: {1:0.00}", emojiName, value);
                ////        g.DrawString(c, aFont, (value > 50) ? whitePen.Brush : redPen.Brush, new PointF(br.X, padding += spacing));
                ////    }
                ////}
                //
                ////g.DrawString("EXPRESSIONS", aFont, bluePen.Brush, new PointF(br.X, padding += (spacing * 2)));
                ////foreach (PropertyInfo prop in typeof(Affdex.Expressions).GetProperties())
                ////{
                ////    float value = (float)prop.GetValue(face.Expressions, null);
                ////    String c = String.Format("{0}: {1:0.00}", prop.Name, value);
                ////    g.DrawString(c, aFont, (value > 50) ? whitePen.Brush : redPen.Brush, new PointF(br.X, padding += spacing));
                ////}
                //
                ////g.DrawString("EMOTIONS", aFont, bluePen.Brush, new PointF(br.X, padding += (spacing * 2)));
                //foreach (PropertyInfo prop in typeof(Affdex.Emotions).GetProperties())
                //{
                //    float value = (float)prop.GetValue(face.Emotions, null);
                //    String c = String.Format("{0}: {1:0.00}", prop.Name, value);
                //    g.DrawString(c, aFont, (value > 50) ? whitePen.Brush : redPen.Brush, new PointF(br.X, padding += spacing));
                //}

            }
            this.comm_results();
        }

        private void comm_results()
        {
            if (faces.Count > 0)
            {
                foreach (KeyValuePair<int, Affdex.Face> pair in faces) {
                    Affdex.Face face = pair.Value;
                    this.affectivaResult[0] = face.Emotions.Joy; // Single face assumed
                    this.affectivaResult[1] = face.Emotions.Sadness;
                    this.affectivaResult[2] = face.Emotions.Anger;
                    this.affectivaResult[3] = face.Emotions.Surprise;
                    this.affectivaResult[4] = face.Emotions.Fear;
                }
            }
            ResultsChanged(this, EventArgs.Empty); //Invoke Event
        }

        public void onProcessingException(Affdex.AffdexException A_0)
        {
            //System.Console.WriteLine("Encountered an exception while processing {0}", A_0.ToString());
        }

        public void onProcessingFinished()
        {
            //System.Console.WriteLine("Processing finished successfully");
        }

        Affdex.FeaturePoint minPoint(Affdex.FeaturePoint[] points)
        {
            Affdex.FeaturePoint ret = points[0];
            foreach (Affdex.FeaturePoint point in points)
            {
                if (point.X < ret.X) ret.X = point.X;
                if (point.Y < ret.Y) ret.Y = point.Y;
            }
            return ret;
        }

        Affdex.FeaturePoint maxPoint(Affdex.FeaturePoint[] points)
        {
            Affdex.FeaturePoint ret = points[0];
            foreach (Affdex.FeaturePoint point in points)
            {
                if (point.X > ret.X) ret.X = point.X;
                if (point.Y > ret.Y) ret.Y = point.Y;
            }
            return ret;
        }

        [HandleProcessCorruptedStateExceptions]
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                // rwLock.AcquireReaderLock(Timeout.Infinite);
                if (img != null)
                {
                    this.Width = img.Width;
                    this.Height = img.Height;

                    this.Parent.Width = this.Width;
                    this.Parent.Height = this.Height;

                    try
                    {
                        e.Graphics.DrawImage((Image)img, new Point(0, 0));
                    }
                    catch { }
                }

                if (faces != null) DrawResults(e.Graphics, faces);

                e.Graphics.Flush();
            }
            catch (System.AccessViolationException exp)
            {
                System.Console.WriteLine("Encountered AccessViolationException.");
            }
        }

        private float process_last_timestamp = -1.0f;
        private float process_fps = -1.0f;

        private Bitmap img { get; set; }
        private Dictionary<int, Affdex.Face> faces { get; set; }
        //private Affdex.Detector detector { get; set; }
        private ReaderWriterLock rwLock { get; set; }
    }
}

public static class GraphicsExtensions
{
    public static void DrawCircle(this Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
    {
        g.DrawEllipse(pen, centerX - radius, centerY - radius,
                      radius + radius, radius + radius);
    }
}
