using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SignaliEdge
{
    public partial class Form1 : Form
    {
        readonly ImageHandler imageHandler = new ImageHandler();
        readonly Detector detector = new Detector();
        public Form1()
        {
            InitializeComponent();
            fdIzborSlike = new OpenFileDialog {RestoreDirectory = true, FilterIndex = 1}; 
            //fdIzborSlike.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";

            double lower = 0.02, upper = 0.08;
            trbLower.Value = 2;
            trbUpper.Value = 8;
            lblLowerTreshold.Text = lower.ToString();
            lblUpperTreshold.Text = upper.ToString();
            detector.LowerTreshold = lower;
            detector.UpperTreshold = upper;
            detector.MaxPrecision = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnFileDialog_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != fdIzborSlike.ShowDialog()) return;
            pbSlika.Image = null;
            pbSlikaOriginal.Image = null;
            
            if (imageHandler.CurrentBitmap != null) imageHandler.CurrentBitmap.Dispose();
            if (imageHandler.OriginalBitmap != null) imageHandler.OriginalBitmap.Dispose();

            imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(fdIzborSlike.FileName);
            imageHandler.OriginalBitmap = (Bitmap)Image.FromFile(fdIzborSlike.FileName);
            imageHandler.BitmapPath = fdIzborSlike.FileName;

            pbSlikaOriginal.Image = imageHandler.OriginalBitmap;

            lblImageResolution.Text = pbSlikaOriginal.Image.Width.ToString() + "x" + pbSlikaOriginal.Image.Height.ToString();
            lblImageSize.Text = Math.Round((new FileInfo(fdIzborSlike.FileName).Length/1000000.0), 2).ToString() + "MB";
        }

        private void trbLower_Scroll(object sender, EventArgs e)
        {
            var v = trbLower.Value/100.0;
            detector.LowerTreshold = v;
            lblLowerTreshold.Text = v.ToString();
        }

        private void trbUpper_Scroll(object sender, EventArgs e)
        {
            var v = trbUpper.Value/100.0;
            detector.UpperTreshold = v;
            lblUpperTreshold.Text = v.ToString();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            lblLastDetection.Text = "Working...";

            imageHandler.SetGrayscale();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                var n = imageHandler.GetNormalizedMatrix();
                var slika = detector.Detection(n, trbPrecision.Value);

                imageHandler.DenormalizeCurrent(slika);

                n = null;
                slika = null;

                sw.Stop();
                string elapsed = sw.Elapsed.ToString();
                lblLastDetection.Text = elapsed.Substring(0, 11);
                Console.WriteLine("Done after: " + sw.Elapsed);

                detector.CleanUp();
                GC.Collect();

                // Konacno postavi sliku
                pbSlika.Image = imageHandler.CurrentBitmap;
            }
            catch (OutOfMemoryException)
            {
                pbSlika.Image = null; pbSlika.Dispose();
                pbSlikaOriginal.Image = null; pbSlikaOriginal.Dispose();
                imageHandler.CleanUp();
                detector.CleanUp();
                lblLastDetection.Text = "0";
                MessageBox.Show("The image you choose is too big. Please choose a smaller image and try again.");
            }

            Cursor = Cursors.Default;
        }

        private void cbCalcTresholds_CheckedChanged(object sender, EventArgs e)
        {
            detector.LowerTreshold = 0;
            detector.UpperTreshold = 0;

            trbUpper.Value = 0;
            trbLower.Value = 0;

            lblLowerTreshold.Text = "0.0";
            lblUpperTreshold.Text = "0.0";

            trbLower.Enabled = !trbLower.Enabled;
            trbUpper.Enabled = !trbUpper.Enabled;
        }

        private void cbMaxPrecision_CheckedChanged(object sender, EventArgs e)
        {
            trbPrecision.Value = 1;
            lblPrecision.Text = "1";
            trbPrecision.Enabled = !trbPrecision.Enabled;
            detector.MaxPrecision = !detector.MaxPrecision;
        }

        private void trbPrecision_Scroll(object sender, EventArgs e)
        {
            lblPrecision.Text = trbPrecision.Value.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

    }
}
