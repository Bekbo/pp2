using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcWithClass
{
    public partial class Form1 : Form
    {
        CalcBase calc;
        public Form1()
        {
            InitializeComponent();
            calc = new CalcBase();
        }

        private void numbers_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            Button btn = sender as Button; // (Button) sender;
            textBox1.Text += btn.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calc.first_number = float.Parse(textBox1.Text);
            calc.operation = btn.Text;
            textBox1.Text = "0";
        }

        private void result_click(object sender, EventArgs e)
        {
            calc.second_number = float.Parse(textBox1.Text);
            calc.calculate();
            textBox1.Text = calc.result+"";
        }

        private void clear_clicked(object sender, EventArgs e)
        {
            calc = new CalcBase();
            textBox1.Text = "0";
        }
    }
}
