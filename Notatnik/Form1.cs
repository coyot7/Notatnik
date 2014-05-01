using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        System.Drawing.FontStyle czcionka;
        string czcionkaRodzaj;
        float wielkosc;

        public Form1()
        {
            InitializeComponent();
            initializeComboxS();
            initializeComboxF();
        }

        private void initializeComboxS()
        {
            object[] size = new object[]{
                10,
                12,
                14,
                16,
                18,
                20};
            comboBox1.Items.AddRange(size);
            comboBox1.SelectedIndex = 0;
        } //ladowanie listy rozmiarow

        private void initializeComboxF() //ladowanie listy nazw czcionek
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (var family in fonts.Families)
            {
                comboBox2.Items.Add(family.Name);
            }
            comboBox2.SelectedIndex = 9; //domyslna arial
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files (*.txt)| *.txt|RTF Files (*rtf)|*.rtf";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {   
                if (openFileDialog1.FilterIndex == 1)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    this.Text = Path.GetFileName(openFileDialog1.FileName);
                }
                else if (openFileDialog1.FilterIndex == 2)
                {
                    richTextBox1.Rtf = File.ReadAllText(openFileDialog1.FileName);
                    this.Text = Path.GetFileName(openFileDialog1.FileName);
                } 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                saveFileDialog1.Filter = "TXT Files (*.txt)| *.txt|RTF Files (*rtf)|*.rtf";

                    if (saveFileDialog1.FilterIndex == 1)
                    {
                        File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
                    }
                    else if (saveFileDialog1.FilterIndex == 2)
                    {
                        File.WriteAllText(openFileDialog1.FileName, richTextBox1.Rtf);
                    }
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TXT Files (*.txt)| *.txt|RTF Files (*rtf)|*.rtf";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                }
                else if (saveFileDialog1.FilterIndex == 2)
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Rtf);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle tmpBold;

            if (richTextBox1.SelectionFont.Bold == false)
            {
                tmpBold = FontStyle.Bold;
            }
            else
            {
                tmpBold = FontStyle.Regular;
                czcionka = FontStyle.Regular;
            }

            richTextBox1.SelectionFont = new Font(
                this.czcionkaRodzaj,
                this.wielkosc,
                this.czcionka = (czcionka | tmpBold)
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle tmpItalic;

            if (richTextBox1.SelectionFont.Italic == false)
            {
                tmpItalic = FontStyle.Italic;
            }
            else
            {
                tmpItalic = FontStyle.Regular;
                czcionka = FontStyle.Regular;
            }

            richTextBox1.SelectionFont = new Font(
                this.czcionkaRodzaj,
                this.wielkosc,
                this.czcionka = (czcionka | tmpItalic)
                );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle tmpUnderline;

            if (richTextBox1.SelectionFont.Underline == false)
            {
                tmpUnderline = FontStyle.Underline;
            }
            else
            {
                tmpUnderline = FontStyle.Regular;
                czcionka = FontStyle.Regular;
            }

            richTextBox1.SelectionFont = new Font(
                this.czcionkaRodzaj,
                this.wielkosc,
                this.czcionka = (czcionka | tmpUnderline)
                );

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowHelp = true;
            dialog.Color = richTextBox1.ForeColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = dialog.Color;
            }
        } //kolor

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(
            this.czcionkaRodzaj,
            this.wielkosc = (float)(int)comboBox1.SelectedItem,
            this.czcionka
            );
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(
                this.czcionkaRodzaj = comboBox2.SelectedItem.ToString(),
                this.wielkosc,
                this.czcionka
                );
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string tekst = "Autor\nGrzegorz Tomiak";
            var okno = MessageBox.Show(tekst);
        }
    }
}