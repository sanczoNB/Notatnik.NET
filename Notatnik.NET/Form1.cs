using System;
using System.Windows.Forms;

namespace Notatnik.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
