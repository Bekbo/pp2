using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        CalcClass calc = new CalcClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            display.Text += btn.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = double.Parse(display.Text);
            calc.operation = btn.Text;
            display.Text = "";
        }

        private void result_click(object sender, EventArgs e)
        {
            calc.second_number = double.Parse(display.Text);
            calc.calculate();
            display.Text = calc.result.ToString();
        }

        private void c_click(object sender, EventArgs e)
        {
            display.Text = "";
            calc.first_number = 0;
            calc.second_number = 0;
            calc.result = 0;
            calc.operation = "";
            //calc = new CalcClass();
        }
    }
}
