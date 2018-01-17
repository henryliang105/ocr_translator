namespace OCRSnipping
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.snipButton = new System.Windows.Forms.Button();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.ocrButton = new System.Windows.Forms.Button();
            this.ocrTextBox = new System.Windows.Forms.TextBox();
            this.translateTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(114, 10);
            this.sourcePictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(150, 160);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // snipButton
            // 
            this.snipButton.Location = new System.Drawing.Point(114, 188);
            this.snipButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.snipButton.Name = "snipButton";
            this.snipButton.Size = new System.Drawing.Size(56, 18);
            this.snipButton.TabIndex = 1;
            this.snipButton.Text = "Snip";
            this.snipButton.UseVisualStyleBackColor = true;
            this.snipButton.Click += new System.EventHandler(this.snipButton_Click);
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(145, 249);
            this.languageComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(92, 20);
            this.languageComboBox.TabIndex = 2;
            // 
            // ocrButton
            // 
            this.ocrButton.Location = new System.Drawing.Point(208, 188);
            this.ocrButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ocrButton.Name = "ocrButton";
            this.ocrButton.Size = new System.Drawing.Size(56, 18);
            this.ocrButton.TabIndex = 3;
            this.ocrButton.Text = "OCR";
            this.ocrButton.UseVisualStyleBackColor = true;
            this.ocrButton.Click += new System.EventHandler(this.ocrButton_Click);
            // 
            // ocrTextBox
            // 
            this.ocrTextBox.Location = new System.Drawing.Point(28, 288);
            this.ocrTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ocrTextBox.Multiline = true;
            this.ocrTextBox.Name = "ocrTextBox";
            this.ocrTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ocrTextBox.Size = new System.Drawing.Size(158, 119);
            this.ocrTextBox.TabIndex = 4;
            // 
            // translateTextBox
            // 
            this.translateTextBox.Location = new System.Drawing.Point(189, 288);
            this.translateTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.translateTextBox.Multiline = true;
            this.translateTextBox.Name = "translateTextBox";
            this.translateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.translateTextBox.Size = new System.Drawing.Size(158, 119);
            this.translateTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 416);
            this.Controls.Add(this.translateTextBox);
            this.Controls.Add(this.ocrTextBox);
            this.Controls.Add(this.ocrButton);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.snipButton);
            this.Controls.Add(this.sourcePictureBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Snip";
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.Button snipButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button ocrButton;
        private System.Windows.Forms.TextBox ocrTextBox;
        private System.Windows.Forms.TextBox translateTextBox;
    }
}

