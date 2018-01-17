using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.OCR;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OCRSnipping
{
    public partial class Form1 : Form
    {
        private Tesseract ocr;
        private Bitmap screenImage;
        private bool isMouseDown = false;

        public Form1()
        {
            InitializeComponent();
            ocr = new Tesseract("../../../tessdata", "eng", OcrEngineMode.TesseractCubeCombined);
            languageComboBox.Items.AddRange(Translator.Languages.ToArray());
            languageComboBox.SelectedItem = "ChineseTrad";
        }

        private void snipButton_Click(object sender, EventArgs e)
        {
            screenImage = (Bitmap)SnippingTool.Snip();
            /*if (bmp != null)
            {
                // Do something with the bitmap
                //...
            }*/
            sourcePictureBox.Image = screenImage;
        }

        private void ocrButton_Click(object sender, EventArgs e)
        {
            Image<Gray, Byte> grayImage = new Image<Gray, Byte>(screenImage);
            ocr.Recognize(grayImage);
            ocrTextBox.Text = ocr.GetText();

            // Initialize the translator
            Translator t = new Translator();

            // Translate the text
            try
            {
                string ocrText = ocrTextBox.Text;
                ocrText = ocrText.Replace(Environment.NewLine, " ");

                translateTextBox.Text = t.Translate(ocrText, "English", (string)this.languageComboBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
