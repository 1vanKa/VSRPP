using bntu.vsrpp.ikarpovich.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bntu.vsrpp.ikarpovich.lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //"E:\\study\\c#\\bntu.vsrpp.ikarpovich\\lab1_example1.xml"
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            XmlParser xmlParser = new(openFileDialog.FileName);
            richTextBox1.Text = xmlParser.ToString();
        }
    }
}
