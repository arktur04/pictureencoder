namespace WindowsFormsApplication1
{
    partial class mainForm
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.infoLabel = new System.Windows.Forms.Label();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.imageFormatComboBox = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.paletteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 301);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Открыть";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 282);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 13);
            this.infoLabel.TabIndex = 2;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(93, 301);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 3;
            this.saveFileButton.Text = "Сохранить";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(243, 301);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(90, 23);
            this.aboutButton.TabIndex = 4;
            this.aboutButton.Text = "О программе";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageFormatComboBox
            // 
            this.imageFormatComboBox.FormattingEnabled = true;
            this.imageFormatComboBox.Items.AddRange(new object[] {
            "8 bit (paletted)",
            "16 bit (1bit intensity + 5 bit R + 5 bit G + 5 bit B)",
            "24 bit in 32 bit unsigned int (0x00 + 24 bit RGB)"});
            this.imageFormatComboBox.Location = new System.Drawing.Point(93, 274);
            this.imageFormatComboBox.Name = "imageFormatComboBox";
            this.imageFormatComboBox.Size = new System.Drawing.Size(240, 21);
            this.imageFormatComboBox.TabIndex = 5;
            this.imageFormatComboBox.Text = "24 bit in 32 bit unsigned int (0x00 + 24 bit RGB)";
            this.imageFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.pix;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(321, 240);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // paletteButton
            // 
            this.paletteButton.Location = new System.Drawing.Point(12, 330);
            this.paletteButton.Name = "paletteButton";
            this.paletteButton.Size = new System.Drawing.Size(75, 23);
            this.paletteButton.TabIndex = 6;
            this.paletteButton.Text = "Палитра";
            this.paletteButton.UseVisualStyleBackColor = true;
            this.paletteButton.Click += new System.EventHandler(this.paletteButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 365);
            this.Controls.Add(this.paletteButton);
            this.Controls.Add(this.imageFormatComboBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.openFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "Конвертация изображения";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.ComboBox imageFormatComboBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button paletteButton;
    }
}

