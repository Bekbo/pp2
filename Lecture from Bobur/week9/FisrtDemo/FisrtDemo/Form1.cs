using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisrtDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = btn.Text;
        }

        private void my_button_click(object sender, EventArgs e)
        {
            MessageBox.Show("my button click function called");
        }

    }
}
