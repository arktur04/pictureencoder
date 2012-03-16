using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        private Bitmap bmp;
        string currentPath;
        enum ImageFormat { ImageFormat8bit, ImageFormat16Bit, ImageFormat24Bit };
        ImageFormat imageFormat = ImageFormat.ImageFormat24Bit;
        int lineLengthConstraint = 80;

        public mainForm()
        {
            InitializeComponent();

            PaletteForm.loadDefaultPalette();
            PaletteForm.lineLengthConstraint = lineLengthConstraint;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            //  Bitmap bmp = new Bitmap(0, 0);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (currentPath == "")
            {
                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            };

            openFileDialog1.Filter = "png files (*.png)|*.png|" +
                "bmp files (*.bmp)|*.bmp|" +
                "gif files (*.gif)|*.gif|" +
                "exif files (*.exif)|*.exif|" +
                "jpg files (*.jpg)|*.jpg|" +
                "tiff files (*.tiff)|*.tiff|" +
                "All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentPath = openFileDialog1.FileName;
                    bmp = new Bitmap(currentPath);
                    if (bmp != null)
                    {
                        pictureBox.Image = bmp;
                        infoLabel.Text = bmp.Width.ToString() + "х" + bmp.Height.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Файл не открывается. \r\n Original error: " + ex.Message,
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
            aboutForm.Left = Left + (Width - aboutForm.Width) / 2;
            aboutForm.Top = Top + (Height - aboutForm.Height) / 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageFormat = (ImageFormat)imageFormatComboBox.SelectedIndex;
        }

        private string ColorToString(Color color)
        {
            switch (imageFormat)
            {
                    //8-bit format
                case ImageFormat.ImageFormat8bit:
                    return String.Format("0x{0:X2}", PaletteForm.colorToPaletteIndex(color));
                //16-bit format
                case ImageFormat.ImageFormat16Bit:
                    return String.Format("0x{0:X4}", (((Int16)1 << 15) |
                                                     (((Int16)color.R & 0xF8) << 7) |
                                                     (((Int16)color.G & 0xF8) << 2) |
                                                     (((Int16)color.B & 0xF8) >> 3)));
                //24-bit format
                case ImageFormat.ImageFormat24Bit:
                    return String.Format("0x00{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            };
            return ""; //not reachable line indeed
        }

        private void saveBmpToFile(string FileName)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(FileName))
                {
                    int charCounter;
                    string s;
                    progressBar.Maximum = bmp.Height - 1;
                    progressBar.Value = 0;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        sw.WriteLine(@"{");
                        charCounter = 0;
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color color = bmp.GetPixel(x, y);
                            string postfix = (x == bmp.Width - 1) ? "" : ", ";
                            s = ColorToString(color) + postfix;

                            charCounter += s.Length;
                            if ((lineLengthConstraint > 0) && (charCounter > lineLengthConstraint))
                            {
                                sw.WriteLine();
                                charCounter = s.Length;
                            }
                            sw.Write(s);
                        };
                        sw.WriteLine("},");
                        progressBar.Value = y;
                    };
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения файла.\r\n Original error: " + ex.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(currentPath);
                saveFileDialog.Filter = "c files (*.c)|*.c|" +
                "txt files (*.txt)|*.txt|" +
                "All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveBmpToFile(saveFileDialog.FileName);
                }
            }
        }

        private void paletteButton_Click(object sender, EventArgs e)
        {
            PaletteForm paletteForm = new PaletteForm();
            paletteForm.currentPath = currentPath;
            paletteForm.ShowDialog();
        }
    }
}
