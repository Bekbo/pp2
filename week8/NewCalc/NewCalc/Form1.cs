using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCalc
{
    public partial class Form1 : Form
    {
        public char oper = ' ';
        public double a;
        public bool clr, tochka = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            BackgroundImage = Image.FromFile(@"C:\Users\User\Desktop\Univer\pp2\week8\NewCalc\NewCalc\bin\Debug/im.png");
            int k = 1;
            int x = 50, y = 50;

            for (int i = 0; i < 3; i++)
            {
                for (int  j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Text = k.ToString();
                    k++;
                    button.Size = new Size(50, 50);
                    button.Click += new EventHandler(number_Click);
                    button.Location = new Point(10 + x * j, 30+ y * i);
                    Controls.Add(button);
                }
            }

            Button plus = new Button();
            plus.Text = "+";
            plus.Size = new Size(50, 50);
            plus.Location = new Point(160, 30);
            plus.Click += new EventHandler(plus_Click);
            Controls.Add(plus);

            Button minus = new Button();
            minus.Text = "-";
            minus.Size = new Size(50, 50);
            minus.Location = new Point(210, 30);
            minus.Click += new EventHandler(minus_Click);
            Controls.Add(minus);

            Button square = new Button();
            square.Text = "х²";
            square.Size = new Size(50, 50);
            square.Location = new Point(260, 30);
            square.Click += new EventHandler(square_Click);
            Controls.Add(square);

            Button mul = new Button();
            mul.Text = "*";
            mul.Size = new Size(50, 50);
            mul.Location = new Point(160, 80);
            mul.Click += new EventHandler(mul_Click);
            Controls.Add(mul);

            Button div = new Button();
            div.Text = "/";
            div.Size = new Size(50, 50);
            div.Location = new Point(210, 80);
            div.Click += new EventHandler(div_Click);
            Controls.Add(div);

            Button bclear = new Button();
            bclear.Text = "C";
            bclear.Size = new Size(50, 50);
            bclear.Location = new Point(160, 130);
            bclear.Click += new EventHandler(bclear_Click);
            Controls.Add(bclear);

            Button result = new Button();
            result.Text = "=";
            result.Size = new Size(50, 50);
            result.Location = new Point(210, 130);
            result.Click += new EventHandler(result_Click);
            Controls.Add(result);

            Button dot = new Button();
            dot.Text = ",";
            dot.Size = new Size(50, 50);
            dot.Location = new Point(10, 180);
            dot.Click += new EventHandler(dot_Click);
            Controls.Add(dot);

            Button zero = new Button();
            zero.Text = "0";
            zero.Size = new Size(50, 50);
            zero.Location = new Point(60, 180);
            zero.Click += new EventHandler(zero_Click);
            Controls.Add(zero);

            Button sin = new Button();
            sin.Text = "sin";
            sin.Size = new Size(50, 50);
            sin.Location = new Point(110, 180);
            sin.Click += new EventHandler(sin_Click);
            Controls.Add(sin);

            Button cos = new Button();
            cos.Text = "cos";
            cos.Size = new Size(50, 50);
            cos.Location = new Point(160, 180);
            cos.Click += new EventHandler(cos_Click);
            Controls.Add(cos);

            Button root = new Button();
            root.Text = "√";
            root.Size = new Size(50, 50);
            root.Location = new Point(210, 180);
            root.Click += new EventHandler(root_Click);
            Controls.Add(root);
        }
        private void bclear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void square_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            textBox1.Text = a*a + "";
            clr = true;
        }

        private void root_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            textBox1.Text = Math.Sqrt(a) + "";
            clr = true;
        }
        private void sin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Math.PI * Convert.ToDouble(textBox1.Text) / 180.0;
            textBox1.Clear();
            textBox1.Text = Math.Sin(a) + "";
            clr = true;
        }

        private void cos_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Math.PI * Convert.ToDouble(textBox1.Text) / 180.0;
            textBox1.Clear();
            textBox1.Text = Math.Cos(a) + "";
            clr = true;
        }

        private void zero_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }
        private void dot_Click(object sender, EventArgs e)
        {
            if (tochka == false)
            {
                Button button = sender as Button;
                textBox1.Text += button.Text;
                tochka = true;
            }
        }
        private void plus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            oper = '+';
            tochka = false;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            oper = '-';
            tochka = false;
        }

        private void mul_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            oper = '*';
            tochka = false;
        }

        private void div_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                a = 0;
            else
                a = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            oper = '/';
            tochka = false;
        }

        private void result_Click(object sender, EventArgs e)
        {
            double res = 0;
            if (oper == '+')
            {
                res = a + Convert.ToDouble(textBox1.Text);
            }
            if (oper == '-')
            {
                res = a - Convert.ToDouble(textBox1.Text);
            }
            if (oper == '*')
            {
                res = a * Convert.ToDouble(textBox1.Text);
            }
            if (oper == '/')
            {
                res = a / Convert.ToDouble(textBox1.Text);
            }
            clr = true;
            textBox1.Clear();
            textBox1.Text = res + "";
            tochka = false;
        }

        private void number_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Clear();
            }
            if (clr)
            {
                textBox1.Clear();
                clr = false;
            }
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }
    }
}
