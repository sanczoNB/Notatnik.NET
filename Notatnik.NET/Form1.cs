using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Notatnik.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string[] ReadTextFile(string fileName)
        {
            var text = new List<string>();
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    string row;
                    while ((row = sr.ReadLine()) != null)
                    {
                        text.Add(row);
                    }
                }
                return text.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd odczytu pliku  {fileName} \nOpis wyjątku: {e.Message}", 
                    "Notatnik.NET - Błąd przy wczytywaniu pliku",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            //Application.Exit(); drugi sposób 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy zapisać zmiany w edytowanym dokumencie ?",
                this.Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);
            switch (dr)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Wstawić wywołanie metody zapisującej zawartość notatnika do pliku");
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void pasekstanuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = pasekstanuToolStripMenuItem.Checked;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                textBox1.Lines = ReadTextFile(fileName);
                int lastSlah = fileName.LastIndexOf('\\');
                toolStripStatusLabel1.Text = fileName.Substring(lastSlah + 1);
            }
        }
    }
}
