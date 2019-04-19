using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class Form1 : Form
    {
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            label1.Text = cnt + "";
        }
    }
}
