using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class PaletteForm : Form
    {
        const UInt16 rMask = (0x1F << 10);
        const UInt16 gMask = (0x1F << 5);
        const UInt16 bMask = 0x1F;

        private const int paletteSize = 256;
        private static UInt16[] palette = new UInt16[paletteSize];
        public string currentPath { set; get; }
        public static int lineLengthConstraint { set; get; }
        enum PaletteMode { PaletteModeR2_G3_B3, PaletteModeR3_G2_B3, PaletteModeR3_G3_B2 };
        static PaletteMode paletteMode;

        public PaletteForm()
        {
            InitializeComponent();
        }

        public static byte colorToPaletteIndex(Color color)
        {
            int minDist2 = 0;
            byte index = 0;
            for (int i = 0; i < paletteSize; i++)
            {
                int Dist2 = (int)Math.Pow((color.R - ((palette[i] & 0x7C00) >> 7)), 2) +
                    (int)Math.Pow((color.G - ((palette[i] & 0x03E0) >> 2)), 2) +
                    (int)Math.Pow((color.B - (byte)((palette[i] & 0x1F) << 3)), 2);
                if (i > 0)
                {
                    if (minDist2 > Dist2)
                    {
                        minDist2 = Dist2;
                        index = (byte)i;
                    }
                }
                else 
                {
                    minDist2 = Dist2;
                    index = 0;
                }
            }
            return index;
        }

        protected static Color paletteIndexToColor(byte index)
        {
            byte R = 0, G = 0, B = 0;
            switch (paletteMode)
            {
                case PaletteMode.PaletteModeR2_G3_B3:
                    R = (byte)((((index & 0xc0) >> 6) * 255) / 3);
                    G = (byte)((((index & 0x38) >> 3) * 255) / 7);
                    B = (byte)(((index & 0x07) * 255) / 7);
                    break;
                case PaletteMode.PaletteModeR3_G2_B3:
                    R = (byte)((((index & 0xe0) >> 5) * 255) / 7);
                    G = (byte)((((index & 0x18) >> 3) * 255) / 3);
                    B = (byte)(((index & 0x07) * 255) / 7);
                    break;
                case PaletteMode.PaletteModeR3_G3_B2:
                    R = (byte)((((index & 0xe0) >> 5) * 255) / 7);
                    G = (byte)((((index & 0x1c) >> 2) * 255) / 7);
                    B = (byte)(((index & 0x03) * 255) / 3);
                    break;
            };
            return Color.FromArgb(0, R, G, B);
        }

        private UInt16 colorToPaletteEntry(Color color)
        {
            UInt16 b = (UInt16)(color.B >> 3);
            UInt16 g = (UInt16)((color.G & 0xF8) << 2);
            UInt16 r = (UInt16)((color.R & 0xF8) << 7);
            return (UInt16)(r | g | b);
        }

        private Color paletteEntryToColor(UInt16 val)
        {
            return Color.FromArgb(0, (val & rMask) >> 7, (val & gMask) >> 2, (val & bMask) << 2); 
        }

        private void generatePalette()
        {
            for (int i = 0; i < paletteSize; i++)
            {
                palette[i] = colorToPaletteEntry(paletteIndexToColor((byte)i));
               
                toolStripProgressBar.Value = i;
                toolStripProgressBar.Invalidate();
                Application.DoEvents();
            };
        }

        protected void refreshPalette()
        {
            palettePictureBox.Invalidate();
        }

        private void palettePictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < paletteSize; i++)
            {
               // Color color = Color.FromArgb((int)palette[i]);
                Color color = Color.FromArgb(255, paletteEntryToColor(palette[i]));
                g.FillRectangle(new SolidBrush(color),
                new Rectangle((i * palettePictureBox.Width) / 256,
                    0,
                    ((i + 1) * palettePictureBox.Width) / 256 - 1,
                    palettePictureBox.Height - 1));
            };
        }

        private void refreshTextBox()
        {
            paletteTextBox.Clear();
            for (int i = 0; i < paletteSize; i++)
            {
                paletteTextBox.Text += String.Format("{0}-0x{1:X4}  ", i, palette[i]);
                toolStripProgressBar.Value = i + 256;
                toolStripProgressBar.Invalidate();
                Application.DoEvents();
            };
        }

        private void unselectRadioButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void refreshAll()
        {
            refreshTextBox();
            refreshPalette();
        }

        private void PaletteForm_Shown(object sender, EventArgs e)
        {
            unselectRadioButtons();
            refreshAll();
        }

        private void palettePictureBox_Resize(object sender, EventArgs e)
        {
            refreshPalette();
        }

        private void savePaletteButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "palette files (*.palette)|*.palette|" +
                            "All files (*.*)|*.*"; ;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UInt16[]));
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                serializer.Serialize(writer, palette);
                writer.Close();
            }
        }

        private void openPaletteButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "palette files (*.palette)|*.palette|" +
                            "All files (*.*)|*.*"; ;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadPalette(openFileDialog.FileName);
                unselectRadioButtons();
                refreshAll();
            }
        }

        private static void loadPalette(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UInt16[]));
                palette = (UInt16[])serializer.Deserialize(reader);
            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public static void loadDefaultPalette()
        {
            loadPalette(Application.StartupPath + "\\default.palette");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                paletteMode = PaletteMode.PaletteModeR2_G3_B3;
                generatePalette();
                refreshAll();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                paletteMode = PaletteMode.PaletteModeR3_G2_B3;
                generatePalette();
                refreshAll();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                paletteMode = PaletteMode.PaletteModeR3_G3_B2;
                generatePalette();
                refreshAll();
            }
        }

        private void saveToCArray_Click(object sender, EventArgs e)
        {
            if (currentPath == "")
            {
                saveToCArrayFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else
            {
                saveToCArrayFileDialog.InitialDirectory = Path.GetDirectoryName(currentPath);
            };
            saveToCArrayFileDialog.Filter = "c files (*.c)|*.c|" +
            "All files (*.*)|*.*";
            saveToCArrayFileDialog.FilterIndex = 1;
            saveToCArrayFileDialog.RestoreDirectory = true;
            if (saveToCArrayFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePaletteToCFile(saveToCArrayFileDialog.FileName);
            }
        }

        private void savePaletteToCFile(string fileName)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    int charCounter;
                    string s;
                    sw.WriteLine(@"{");
                    charCounter = 0;
                    for (int i = 0; i < paletteSize; i++)
                    {
                        string postfix = (i == paletteSize - 1) ? "" : ", ";
                        s = String.Format("0x{0:X4}", palette[i]) + postfix;
                        charCounter += s.Length;

                        if ((lineLengthConstraint > 0) && (charCounter > lineLengthConstraint))
                        {
                            sw.WriteLine();
                            charCounter = s.Length;
                        }
                        sw.Write(s);
                    };
                    sw.WriteLine("};");
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
    }
}
