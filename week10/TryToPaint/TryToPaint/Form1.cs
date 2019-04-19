using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryToPaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnOk.Text = "Hello";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar1.Value = int.Parse(numericUpDown1.Value.ToString());
        }
        int k = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 101)
            {
                timer1.Stop();
            }
            k++;
            label1.Text = k + "";
            progressBar1.Value++;
        }
    }
}
