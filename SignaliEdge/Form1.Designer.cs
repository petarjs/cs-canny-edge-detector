namespace SignaliEdge
{
    partial class Form1
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
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.fdIzborSlike = new System.Windows.Forms.OpenFileDialog();
            this.trbLower = new System.Windows.Forms.TrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbSlikaOriginal = new System.Windows.Forms.PictureBox();
            this.trbUpper = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFileDialog = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.lblLowerTreshold = new System.Windows.Forms.Label();
            this.lblUpperTreshold = new System.Windows.Forms.Label();
            this.cbCalcTresholds = new System.Windows.Forms.CheckBox();
            this.trbPrecision = new System.Windows.Forms.TrackBar();
            this.lblPrecisionText = new System.Windows.Forms.Label();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.cbMaxPrecision = new System.Windows.Forms.CheckBox();
            this.ssInfo = new System.Windows.Forms.StatusStrip();
            this.lblLastDetectionText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastDetection = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblS = new System.Windows.Forms.ToolStripStatusLabel();
            this.spring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblImageText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblImageResolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrecision)).BeginInit();
            this.ssInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSlika
            // 
            this.pbSlika.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSlika.InitialImage = null;
            this.pbSlika.Location = new System.Drawing.Point(3, 0);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(320, 281);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSlika.TabIndex = 0;
            this.pbSlika.TabStop = false;
            // 
            // fdIzborSlike
            // 
            this.fdIzborSlike.FileName = "openFileDialog1";
            // 
            // trbLower
            // 
            this.trbLower.Location = new System.Drawing.Point(13, 155);
            this.trbLower.Maximum = 100;
            this.trbLower.Name = "trbLower";
            this.trbLower.Size = new System.Drawing.Size(272, 45);
            this.trbLower.TabIndex = 1;
            this.trbLower.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trbLower.Scroll += new System.EventHandler(this.trbLower_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 205);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbSlikaOriginal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbSlika);
            this.splitContainer1.Size = new System.Drawing.Size(659, 286);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 2;
            // 
            // pbSlikaOriginal
            // 
            this.pbSlikaOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSlikaOriginal.InitialImage = null;
            this.pbSlikaOriginal.Location = new System.Drawing.Point(3, 3);
            this.pbSlikaOriginal.Name = "pbSlikaOriginal";
            this.pbSlikaOriginal.Size = new System.Drawing.Size(319, 278);
            this.pbSlikaOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSlikaOriginal.TabIndex = 0;
            this.pbSlikaOriginal.TabStop = false;
            // 
            // trbUpper
            // 
            this.trbUpper.Location = new System.Drawing.Point(336, 155);
            this.trbUpper.Maximum = 100;
            this.trbUpper.Name = "trbUpper";
            this.trbUpper.Size = new System.Drawing.Size(290, 45);
            this.trbUpper.TabIndex = 3;
            this.trbUpper.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trbUpper.Scroll += new System.EventHandler(this.trbUpper_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lower Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Upper Treshold";
            // 
            // btnFileDialog
            // 
            this.btnFileDialog.Location = new System.Drawing.Point(16, 13);
            this.btnFileDialog.Name = "btnFileDialog";
            this.btnFileDialog.Size = new System.Drawing.Size(142, 23);
            this.btnFileDialog.TabIndex = 6;
            this.btnFileDialog.Text = "Choose Image";
            this.btnFileDialog.UseVisualStyleBackColor = true;
            this.btnFileDialog.Click += new System.EventHandler(this.btnFileDialog_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(177, 13);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(149, 23);
            this.btnDetect.TabIndex = 7;
            this.btnDetect.Text = "Detect Edges";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // lblLowerTreshold
            // 
            this.lblLowerTreshold.AutoSize = true;
            this.lblLowerTreshold.Location = new System.Drawing.Point(291, 155);
            this.lblLowerTreshold.Name = "lblLowerTreshold";
            this.lblLowerTreshold.Size = new System.Drawing.Size(22, 13);
            this.lblLowerTreshold.TabIndex = 8;
            this.lblLowerTreshold.Text = "0.0";
            // 
            // lblUpperTreshold
            // 
            this.lblUpperTreshold.AutoSize = true;
            this.lblUpperTreshold.Location = new System.Drawing.Point(632, 155);
            this.lblUpperTreshold.Name = "lblUpperTreshold";
            this.lblUpperTreshold.Size = new System.Drawing.Size(22, 13);
            this.lblUpperTreshold.TabIndex = 9;
            this.lblUpperTreshold.Text = "0.0";
            // 
            // cbCalcTresholds
            // 
            this.cbCalcTresholds.AutoSize = true;
            this.cbCalcTresholds.Location = new System.Drawing.Point(339, 17);
            this.cbCalcTresholds.Name = "cbCalcTresholds";
            this.cbCalcTresholds.Size = new System.Drawing.Size(172, 17);
            this.cbCalcTresholds.TabIndex = 10;
            this.cbCalcTresholds.Text = "Automatic Treshold Calculation";
            this.cbCalcTresholds.UseVisualStyleBackColor = true;
            this.cbCalcTresholds.CheckedChanged += new System.EventHandler(this.cbCalcTresholds_CheckedChanged);
            // 
            // trbPrecision
            // 
            this.trbPrecision.Location = new System.Drawing.Point(13, 83);
            this.trbPrecision.Maximum = 100;
            this.trbPrecision.Minimum = 1;
            this.trbPrecision.Name = "trbPrecision";
            this.trbPrecision.Size = new System.Drawing.Size(273, 45);
            this.trbPrecision.TabIndex = 11;
            this.trbPrecision.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trbPrecision.Value = 50;
            this.trbPrecision.Scroll += new System.EventHandler(this.trbPrecision_Scroll);
            // 
            // lblPrecisionText
            // 
            this.lblPrecisionText.AutoSize = true;
            this.lblPrecisionText.Location = new System.Drawing.Point(22, 64);
            this.lblPrecisionText.Name = "lblPrecisionText";
            this.lblPrecisionText.Size = new System.Drawing.Size(271, 13);
            this.lblPrecisionText.TabIndex = 12;
            this.lblPrecisionText.Text = "Edge Detection Precision (higher values take more time)";
            // 
            // lblPrecision
            // 
            this.lblPrecision.AutoSize = true;
            this.lblPrecision.Location = new System.Drawing.Point(293, 83);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(19, 13);
            this.lblPrecision.TabIndex = 13;
            this.lblPrecision.Text = "50";
            // 
            // cbMaxPrecision
            // 
            this.cbMaxPrecision.AutoSize = true;
            this.cbMaxPrecision.Location = new System.Drawing.Point(339, 82);
            this.cbMaxPrecision.Name = "cbMaxPrecision";
            this.cbMaxPrecision.Size = new System.Drawing.Size(265, 17);
            this.cbMaxPrecision.TabIndex = 14;
            this.cbMaxPrecision.Text = "Maximum Precision - Find all the Lines you can find";
            this.cbMaxPrecision.UseVisualStyleBackColor = true;
            this.cbMaxPrecision.CheckedChanged += new System.EventHandler(this.cbMaxPrecision_CheckedChanged);
            // 
            // ssInfo
            // 
            this.ssInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblImageText,
            this.lblImageResolution,
            this.lblImageSize,
            this.spring,
            this.lblLastDetectionText,
            this.lblLastDetection,
            this.lblS});
            this.ssInfo.Location = new System.Drawing.Point(0, 503);
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.ShowItemToolTips = true;
            this.ssInfo.Size = new System.Drawing.Size(683, 22);
            this.ssInfo.TabIndex = 15;
            this.ssInfo.Text = "Info";
            // 
            // lblLastDetectionText
            // 
            this.lblLastDetectionText.Name = "lblLastDetectionText";
            this.lblLastDetectionText.Size = new System.Drawing.Size(112, 17);
            this.lblLastDetectionText.Text = "Last Detection took:";
            this.lblLastDetectionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastDetection
            // 
            this.lblLastDetection.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLastDetection.Name = "lblLastDetection";
            this.lblLastDetection.Size = new System.Drawing.Size(13, 17);
            this.lblLastDetection.Text = "0";
            this.lblLastDetection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblS
            // 
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(12, 17);
            this.lblS.Text = "s";
            this.lblS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spring
            // 
            this.spring.Name = "spring";
            this.spring.Size = new System.Drawing.Size(399, 17);
            this.spring.Spring = true;
            // 
            // lblImageText
            // 
            this.lblImageText.Name = "lblImageText";
            this.lblImageText.Size = new System.Drawing.Size(43, 17);
            this.lblImageText.Text = "Image:";
            // 
            // lblImageResolution
            // 
            this.lblImageResolution.Name = "lblImageResolution";
            this.lblImageResolution.Size = new System.Drawing.Size(24, 17);
            this.lblImageResolution.Text = "0x0";
            // 
            // lblImageSize
            // 
            this.lblImageSize.Name = "lblImageSize";
            this.lblImageSize.Size = new System.Drawing.Size(34, 17);
            this.lblImageSize.Text = "0 MB";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 525);
            this.Controls.Add(this.ssInfo);
            this.Controls.Add(this.cbMaxPrecision);
            this.Controls.Add(this.lblPrecision);
            this.Controls.Add(this.lblPrecisionText);
            this.Controls.Add(this.trbPrecision);
            this.Controls.Add(this.cbCalcTresholds);
            this.Controls.Add(this.lblUpperTreshold);
            this.Controls.Add(this.lblLowerTreshold);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnFileDialog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbUpper);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.trbLower);
            this.Name = "Form1";
            this.Text = "Edge Detector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLower)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrecision)).EndInit();
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.OpenFileDialog fdIzborSlike;
        private System.Windows.Forms.TrackBar trbLower;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TrackBar trbUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFileDialog;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.PictureBox pbSlikaOriginal;
        private System.Windows.Forms.Label lblLowerTreshold;
        private System.Windows.Forms.Label lblUpperTreshold;
        private System.Windows.Forms.CheckBox cbCalcTresholds;
        private System.Windows.Forms.TrackBar trbPrecision;
        private System.Windows.Forms.Label lblPrecisionText;
        private System.Windows.Forms.Label lblPrecision;
        private System.Windows.Forms.CheckBox cbMaxPrecision;
        private System.Windows.Forms.StatusStrip ssInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblLastDetectionText;
        private System.Windows.Forms.ToolStripStatusLabel lblLastDetection;
        private System.Windows.Forms.ToolStripStatusLabel lblS;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripStatusLabel lblImageText;
        private System.Windows.Forms.ToolStripStatusLabel lblImageResolution;
        private System.Windows.Forms.ToolStripStatusLabel lblImageSize;
    }
}

