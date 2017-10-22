using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS_Affectiva
{
    public partial class MainForm : Form
    {
        private AffectivaSurface affSurface = null;
        private long secondsPassed = 0;
        private string[] emotions = { "Joy", "Sadness", "Anger", "Surprise", "Fear" };

        float[] affectivaFloatResults = null; // Results from Affectiva
        float[] textResults_sorted_values = null; // Results from Text

        float entropy_affectiva = 0;
        float entropy_text = 0;

        public MainForm(Affdex.Detector detector)
        {
            InitializeComponent();

            affSurface = new AffectivaSurface(detector);
            this.panel1.Controls.Add(affSurface);
            this.EmotionsTextBox.SelectAll();
            this.EmotionsTextBox.SelectionAlignment = HorizontalAlignment.Right;
            this.EmotionsTextBox.Select(0,0);

            affSurface.ResultsChanged += new System.EventHandler(this.affSurf_ResultsChanged);

            this.textResults_sorted_values = new float[5];

            // Start Timers
            TextTimer.Start();
            secondsTimer.Start();
        }

        private bool firstTimeCalled = false;
        private void affSurf_ResultsChanged(object sender, EventArgs e)
        {
            this.affectivaFloatResults = affSurface.AffectivaResult;

            string s = "";
            foreach (float f in this.affectivaFloatResults)
                s += String.Format("{0:0.00}", f) + "\n";
            s = s.Substring(0, s.Length - 1);
            Invoke(new Action(() => { this.affectivaResultTextBox.Text = s; }));

            float max = this.affectivaFloatResults.Max();
            affDecsiontextBox.Text = emotions[Array.IndexOf(this.affectivaFloatResults, max)];

            //Invoke(new Action(() => { this.textResultTextBox.Text = s; }));

            if (!firstTimeCalled)
            {
                firstTimeCalled = true;
                runTextAnalysisAndCombineResult();
            }
        }

        
        public class TextResultItem
        {
            public string emotion;
            public float probability;
        }
        private void TextTimer_Tick(object sender, EventArgs e)
        {
            this.runTextAnalysisAndCombineResult();
        }

        private void runTextAnalysisAndCombineResult()
        {
            this.runPythonScript("emotion_analyser.py");

            string textResult = File.ReadAllText("text_emotion.txt");
            if (textResult == "")
                return;

            string[] textResults = textResult.Substring(1, textResult.Length - 2).Split(',');
            float[] textResults_values = new float[textResults.Length];
            string[] textResults_emotions = new string[textResults.Length];
            for (int i = 0; i < textResults.Length; i++)
            {
                textResults[i] = textResults[i].Trim();
                textResults_values[i] = float.Parse(textResults[i].Substring(textResults[i].IndexOf(' ') + 1), CultureInfo.InvariantCulture.NumberFormat);
                textResults_emotions[i] = textResults[i].Substring(0, textResults[i].IndexOf(' ')).Replace("\"", "").Replace(":", "");
            }

            for (int i = 0; i < textResults_emotions.Length; i++)
            {
                if (textResults_emotions[i] == "joy")
                    this.textResults_sorted_values[0] = textResults_values[i];
                else if (textResults_emotions[i] == "sadness")
                    this.textResults_sorted_values[1] = textResults_values[i];
                else if (textResults_emotions[i] == "anger")
                    this.textResults_sorted_values[2] = textResults_values[i];
                else if (textResults_emotions[i] == "surprise")
                    this.textResults_sorted_values[3] = textResults_values[i];
                else if (textResults_emotions[i] == "fear")
                    this.textResults_sorted_values[4] = textResults_values[i];
            }

            // Update Text boxes for Text based emotion detection method
            string s = "";
            foreach (float f in this.textResults_sorted_values)
                s += String.Format("{0:0.00}", f) + "\n";
            s = s.Substring(0, s.Length - 1);
            Invoke(new Action(() => { this.textResultTextBox.Text = s; }));

            float max = this.textResults_sorted_values.Max();
            string[] emotions = { "Joy", "Sadness", "Anger", "Surprise", "Fear" };

            textDecsiontextBox.Text = emotions[Array.IndexOf(this.textResults_sorted_values, max)];

            // Combine Results from Affectiva and from Text
            combine_methodology();
        }

        // Combine Results from Affectiva and from Text
        private void combine_methodology()
        {
            if (this.affectivaFloatResults == null || this.textResults_sorted_values == null)
                return;

            // Affect default_weights with entropy
            float[] default_weights = { 0.60f, 0.40f }; // Default weights
            float factor = entropy_affectiva - entropy_text; // -1: affectiva is far better, 0: both are equally better, +1: text is far better
            float range = 0.2f;
            float increase_entropy_affectiva = -1 * range * factor;
            default_weights[0] += increase_entropy_affectiva;
            default_weights[1] -= increase_entropy_affectiva;

            float[] combinedResult = new float[this.affectivaFloatResults.Length];
            for (int i=0; i < this.affectivaFloatResults.Length; i++)
                combinedResult[i] = default_weights[0] * this.affectivaFloatResults[i] +
                                              default_weights[1] * this.textResults_sorted_values[i];

            // Update Text boxes for Text based emotion detection method
            string s = "";
            foreach (float f in combinedResult)
                s += String.Format("{0:0.00}", f) + "\n";
            s = s.Substring(0, s.Length - 1);
            Invoke(new Action(() => { this.affTextResultTextBox.Text = s; }));

            float max = combinedResult.Max();
            string[] emotions = { "Joy", "Sadness", "Anger", "Surprise", "Fear" };

            affTextDecsiontextBox.Text = emotions[Array.IndexOf(combinedResult, max)];
        }

        void runPythonScript(string pyFileName)
        {
            Process python;

            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            pythonInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            pythonInfo.FileName = @"C:\Users\Hesham\AppData\Local\Programs\Python\Python36\python.exe";
            pythonInfo.Arguments = pyFileName;
            pythonInfo.CreateNoWindow = true;
            pythonInfo.UseShellExecute = false;

            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
        }

        private void secondsTimer_Tick(object sender, EventArgs e)
        {
            textTimerLabel.Text = String.Format("{0:00}:{1:00}", (secondsPassed++ / 60), (secondsPassed % 60));

            // Convert affectivaFloatResults to proability distribution
            float[] affectivaFloatResults_prop = new float[this.affectivaFloatResults.Length];
            float sum = this.affectivaFloatResults.Sum();
            for (int i = 0; i < this.affectivaFloatResults.Length; i++)
                affectivaFloatResults_prop[i] = this.affectivaFloatResults[i] / sum;

            // Update Entropies
            // this.entropy_affectiva or entropy_text = 0 means great confidence, 2.322 means no information added
            this.entropy_affectiva = 0;
            this.entropy_text = 0;
            for (int i = 0; i < affectivaFloatResults_prop.Length; i++)
                this.entropy_affectiva += -1 * affectivaFloatResults_prop[i] * (float)Math.Log(affectivaFloatResults_prop[i], 2);
            for (int i = 0; i < this.textResults_sorted_values.Length; i++)
                this.entropy_text += -1 * textResults_sorted_values[i] * (float)Math.Log(textResults_sorted_values[i], 2);

            this.entropy_affectiva /= 2.322f;
            this.entropy_text /= 2.322f;

            affEntropyLabel.Text = String.Format("{0:0.00}/1", entropy_affectiva);
            textEntropyLabel.Text = String.Format("{0:0.00}/1", entropy_text);

            this.combine_methodology();
        }


    }
}
