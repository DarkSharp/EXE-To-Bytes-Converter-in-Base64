using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BytesConverter
{
    public partial class Form1 : MetroForm
    {
        public static Dictionary<string, string> filesToBind = new Dictionary<string, string>();
        public string base64 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Exe File |*.exe";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                metroButton1.Text = dialog.FileName;
                filesToBind.Add(dialog.SafeFileName, dialog.FileName);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            foreach (var file in filesToBind.Values)
            {
                base64 = Convert.ToBase64String(File.ReadAllBytes(file));
            }

            metroTextBox1.Text = base64;
            metroButton1.Text = "Browser";
        }
    }
}
