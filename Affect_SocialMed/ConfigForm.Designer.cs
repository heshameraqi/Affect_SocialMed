namespace VS_Affectiva
{
    partial class ConfigForm
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
            this.modeChecListkbox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.camIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.camFPSNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numFacesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.largeFacesCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.camIDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camFPSNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFacesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // modeChecListkbox
            // 
            this.modeChecListkbox.FormattingEnabled = true;
            this.modeChecListkbox.Items.AddRange(new object[] {
            "Camera",
            "Image",
            "Video"});
            this.modeChecListkbox.Location = new System.Drawing.Point(12, 12);
            this.modeChecListkbox.Name = "modeChecListkbox";
            this.modeChecListkbox.Size = new System.Drawing.Size(71, 49);
            this.modeChecListkbox.TabIndex = 3;
            this.modeChecListkbox.SelectedIndexChanged += new System.EventHandler(this.modeChecListkbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Camera FPS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Camera ID:";
            // 
            // camIDNumericUpDown
            // 
            this.camIDNumericUpDown.Location = new System.Drawing.Point(236, 6);
            this.camIDNumericUpDown.Name = "camIDNumericUpDown";
            this.camIDNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.camIDNumericUpDown.TabIndex = 8;
            this.camIDNumericUpDown.ValueChanged += new System.EventHandler(this.camIDNumericUpDown_ValueChanged);
            // 
            // camFPSNumericUpDown
            // 
            this.camFPSNumericUpDown.Location = new System.Drawing.Point(236, 35);
            this.camFPSNumericUpDown.Name = "camFPSNumericUpDown";
            this.camFPSNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.camFPSNumericUpDown.TabIndex = 9;
            this.camFPSNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.camFPSNumericUpDown.ValueChanged += new System.EventHandler(this.camFPSNumericUpDown_ValueChanged);
            // 
            // numFacesNumericUpDown
            // 
            this.numFacesNumericUpDown.Location = new System.Drawing.Point(236, 61);
            this.numFacesNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFacesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFacesNumericUpDown.Name = "numFacesNumericUpDown";
            this.numFacesNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numFacesNumericUpDown.TabIndex = 11;
            this.numFacesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFacesNumericUpDown.ValueChanged += new System.EventHandler(this.numFacesNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of Faces:";
            // 
            // largeFacesCheckBox
            // 
            this.largeFacesCheckBox.AutoSize = true;
            this.largeFacesCheckBox.Checked = true;
            this.largeFacesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.largeFacesCheckBox.Location = new System.Drawing.Point(192, 87);
            this.largeFacesCheckBox.Name = "largeFacesCheckBox";
            this.largeFacesCheckBox.Size = new System.Drawing.Size(85, 17);
            this.largeFacesCheckBox.TabIndex = 12;
            this.largeFacesCheckBox.Text = "Large Faces";
            this.largeFacesCheckBox.UseVisualStyleBackColor = true;
            this.largeFacesCheckBox.CheckedChanged += new System.EventHandler(this.largeFacesCheckBox_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.largeFacesCheckBox);
            this.Controls.Add(this.numFacesNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.camFPSNumericUpDown);
            this.Controls.Add(this.camIDNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeChecListkbox);
            this.Name = "ConfigForm";
            this.Text = "Configurations";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camIDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camFPSNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFacesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox modeChecListkbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown camIDNumericUpDown;
        private System.Windows.Forms.NumericUpDown camFPSNumericUpDown;
        private System.Windows.Forms.NumericUpDown numFacesNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox largeFacesCheckBox;
    }
}