namespace WindowsFormsApplication1
{
    partial class PaletteForm
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
            this.palettePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.openPaletteButton = new System.Windows.Forms.Button();
            this.paletteTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.savePaletteButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveToArray = new System.Windows.Forms.Button();
            this.saveToCArrayFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // palettePictureBox
            // 
            this.palettePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.palettePictureBox.Location = new System.Drawing.Point(12, 12);
            this.palettePictureBox.Name = "palettePictureBox";
            this.palettePictureBox.Size = new System.Drawing.Size(512, 63);
            this.palettePictureBox.TabIndex = 0;
            this.palettePictureBox.TabStop = false;
            this.palettePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.palettePictureBox_Paint);
            this.palettePictureBox.Resize += new System.EventHandler(this.palettePictureBox_Resize);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор палитры";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(200, 22);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(81, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "R-3 G-3 B-2";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(109, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "R-3 G-2 B-3";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "R-2 G-3 B-3";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // openPaletteButton
            // 
            this.openPaletteButton.Location = new System.Drawing.Point(16, 157);
            this.openPaletteButton.Name = "openPaletteButton";
            this.openPaletteButton.Size = new System.Drawing.Size(116, 23);
            this.openPaletteButton.TabIndex = 2;
            this.openPaletteButton.Text = "Открыть палитру";
            this.openPaletteButton.UseVisualStyleBackColor = true;
            this.openPaletteButton.Click += new System.EventHandler(this.openPaletteButton_Click);
            // 
            // paletteTextBox
            // 
            this.paletteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteTextBox.Location = new System.Drawing.Point(138, 160);
            this.paletteTextBox.Multiline = true;
            this.paletteTextBox.Name = "paletteTextBox";
            this.paletteTextBox.Size = new System.Drawing.Size(385, 77);
            this.paletteTextBox.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 240);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(538, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel.Text = "Создание палитры";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Maximum = 511;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Value = 50;
            // 
            // savePaletteButton
            // 
            this.savePaletteButton.Location = new System.Drawing.Point(16, 186);
            this.savePaletteButton.Name = "savePaletteButton";
            this.savePaletteButton.Size = new System.Drawing.Size(116, 23);
            this.savePaletteButton.TabIndex = 5;
            this.savePaletteButton.Text = "Сохранить палитру";
            this.savePaletteButton.UseVisualStyleBackColor = true;
            this.savePaletteButton.Click += new System.EventHandler(this.savePaletteButton_Click);
            // 
            // saveToArray
            // 
            this.saveToArray.Location = new System.Drawing.Point(16, 214);
            this.saveToArray.Name = "saveToArray";
            this.saveToArray.Size = new System.Drawing.Size(116, 23);
            this.saveToArray.TabIndex = 6;
            this.saveToArray.Text = "Сохранить в C";
            this.saveToArray.UseVisualStyleBackColor = true;
            this.saveToArray.Click += new System.EventHandler(this.saveToCArray_Click);
            // 
            // PaletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 262);
            this.Controls.Add(this.saveToArray);
            this.Controls.Add(this.savePaletteButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.paletteTextBox);
            this.Controls.Add(this.openPaletteButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.palettePictureBox);
            this.Name = "PaletteForm";
            this.Text = "Создание палитры";
            this.Shown += new System.EventHandler(this.PaletteForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.palettePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox palettePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button openPaletteButton;
        private System.Windows.Forms.TextBox paletteTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Button savePaletteButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveToArray;
        private System.Windows.Forms.SaveFileDialog saveToCArrayFileDialog;
    }
}