﻿using System;
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
            int minStep = StringCompare.EditDistance("aassff", "assff");
            MessageBox.Show(minStep.ToString());
        }
    }
}