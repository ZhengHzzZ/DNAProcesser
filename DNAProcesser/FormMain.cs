using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNAProcesser
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_OpenFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    string data = DnaFormatParser.DnaFileParser.Instance.ReadDnaFile(filePath);
                    Console.WriteLine(data);
                }
            }
        }

        private void btn_Compare_Click(object sender, EventArgs e)
        {
            Queue<StringProcessor.EditStruct> queue;
            int minStep = StringProcessor.StringCompare.EditDistance(this.textBox1.Text, this.textBox2.Text, out queue);
            MessageBox.Show(minStep.ToString());
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue().ToString());
            }
        }

        private void btn_Invert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    string outputPath = System.IO.Path.GetDirectoryName(filePath) + "\\" + System.IO.Path.GetFileNameWithoutExtension(filePath) + "_New.jpg";
                    ConvertImage.Invert.InvertColor(filePath, outputPath);
                }
            }
        }
    }
}
