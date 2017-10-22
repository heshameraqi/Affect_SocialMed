namespace VS_Affectiva
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.affTextDecsiontextBox = new System.Windows.Forms.TextBox();
            this.textDecsiontextBox = new System.Windows.Forms.TextBox();
            this.affDecsiontextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.affTextResultTextBox = new System.Windows.Forms.RichTextBox();
            this.affectivaResultTextBox = new System.Windows.Forms.RichTextBox();
            this.textResultTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EmotionsTextBox = new System.Windows.Forms.RichTextBox();
            this.TextTimer = new System.Windows.Forms.Timer(this.components);
            this.textTimerLabel = new System.Windows.Forms.Label();
            this.secondsTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.affEntropyLabel = new System.Windows.Forms.Label();
            this.textEntropyLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 490);
            this.panel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.affTextDecsiontextBox);
            this.groupBox1.Controls.Add(this.textDecsiontextBox);
            this.groupBox1.Controls.Add(this.affDecsiontextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.affTextResultTextBox);
            this.groupBox1.Controls.Add(this.affectivaResultTextBox);
            this.groupBox1.Controls.Add(this.textResultTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EmotionsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(661, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 198);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // affTextDecsiontextBox
            // 
            this.affTextDecsiontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affTextDecsiontextBox.Location = new System.Drawing.Point(304, 165);
            this.affTextDecsiontextBox.Name = "affTextDecsiontextBox";
            this.affTextDecsiontextBox.Size = new System.Drawing.Size(76, 24);
            this.affTextDecsiontextBox.TabIndex = 21;
            this.affTextDecsiontextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDecsiontextBox
            // 
            this.textDecsiontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDecsiontextBox.Location = new System.Drawing.Point(196, 165);
            this.textDecsiontextBox.Name = "textDecsiontextBox";
            this.textDecsiontextBox.Size = new System.Drawing.Size(76, 24);
            this.textDecsiontextBox.TabIndex = 20;
            this.textDecsiontextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // affDecsiontextBox
            // 
            this.affDecsiontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affDecsiontextBox.Location = new System.Drawing.Point(87, 165);
            this.affDecsiontextBox.Name = "affDecsiontextBox";
            this.affDecsiontextBox.Size = new System.Drawing.Size(76, 24);
            this.affDecsiontextBox.TabIndex = 19;
            this.affDecsiontextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(326, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Both";
            // 
            // affTextResultTextBox
            // 
            this.affTextResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affTextResultTextBox.Location = new System.Drawing.Point(315, 50);
            this.affTextResultTextBox.Name = "affTextResultTextBox";
            this.affTextResultTextBox.Size = new System.Drawing.Size(65, 109);
            this.affTextResultTextBox.TabIndex = 17;
            this.affTextResultTextBox.Text = "";
            // 
            // affectivaResultTextBox
            // 
            this.affectivaResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affectivaResultTextBox.Location = new System.Drawing.Point(98, 50);
            this.affectivaResultTextBox.Name = "affectivaResultTextBox";
            this.affectivaResultTextBox.Size = new System.Drawing.Size(65, 109);
            this.affectivaResultTextBox.TabIndex = 16;
            this.affectivaResultTextBox.Text = "";
            // 
            // textResultTextBox
            // 
            this.textResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textResultTextBox.Location = new System.Drawing.Point(207, 50);
            this.textResultTextBox.Name = "textResultTextBox";
            this.textResultTextBox.Size = new System.Drawing.Size(65, 109);
            this.textResultTextBox.TabIndex = 15;
            this.textResultTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(213, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Social\r\nMedia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(94, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Affectiva";
            // 
            // EmotionsTextBox
            // 
            this.EmotionsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.EmotionsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmotionsTextBox.Location = new System.Drawing.Point(6, 50);
            this.EmotionsTextBox.Name = "EmotionsTextBox";
            this.EmotionsTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmotionsTextBox.Size = new System.Drawing.Size(86, 109);
            this.EmotionsTextBox.TabIndex = 12;
            this.EmotionsTextBox.Text = "Joy:\nSadness:\nAnger:\nSurprise:\nFear:";
            this.EmotionsTextBox.WordWrap = false;
            // 
            // TextTimer
            // 
            this.TextTimer.Interval = 60000;
            this.TextTimer.Tick += new System.EventHandler(this.TextTimer_Tick);
            // 
            // textTimerLabel
            // 
            this.textTimerLabel.AutoSize = true;
            this.textTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTimerLabel.Location = new System.Drawing.Point(795, 313);
            this.textTimerLabel.Name = "textTimerLabel";
            this.textTimerLabel.Size = new System.Drawing.Size(60, 24);
            this.textTimerLabel.TabIndex = 14;
            this.textTimerLabel.Text = "00:00";
            // 
            // secondsTimer
            // 
            this.secondsTimer.Interval = 1000;
            this.secondsTimer.Tick += new System.EventHandler(this.secondsTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(663, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Time passed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(663, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Affectiva Entropy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(663, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "Social Media Text Entropy:";
            // 
            // affEntropyLabel
            // 
            this.affEntropyLabel.AutoSize = true;
            this.affEntropyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.affEntropyLabel.Location = new System.Drawing.Point(841, 233);
            this.affEntropyLabel.Name = "affEntropyLabel";
            this.affEntropyLabel.Size = new System.Drawing.Size(21, 24);
            this.affEntropyLabel.TabIndex = 18;
            this.affEntropyLabel.Text = "0";
            // 
            // textEntropyLabel
            // 
            this.textEntropyLabel.AutoSize = true;
            this.textEntropyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEntropyLabel.Location = new System.Drawing.Point(930, 267);
            this.textEntropyLabel.Name = "textEntropyLabel";
            this.textEntropyLabel.Size = new System.Drawing.Size(21, 24);
            this.textEntropyLabel.TabIndex = 19;
            this.textEntropyLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 507);
            this.Controls.Add(this.textEntropyLabel);
            this.Controls.Add(this.affEntropyLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTimerLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Enhance Affectiva with Social Media";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox affectivaResultTextBox;
        private System.Windows.Forms.RichTextBox textResultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox EmotionsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox affTextResultTextBox;
        private System.Windows.Forms.TextBox affTextDecsiontextBox;
        private System.Windows.Forms.TextBox textDecsiontextBox;
        private System.Windows.Forms.TextBox affDecsiontextBox;
        private System.Windows.Forms.Timer TextTimer;
        private System.Windows.Forms.Label textTimerLabel;
        private System.Windows.Forms.Timer secondsTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label affEntropyLabel;
        private System.Windows.Forms.Label textEntropyLabel;

    }
}