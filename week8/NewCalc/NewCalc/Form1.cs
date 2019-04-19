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
        Calculator calc;
        public bool clr, tochka = false,restwice =false;
        public double last = 0;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculator();
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
                    button.Size = new Size(50,50);
                    button.Click += new EventHandler(number_Click);
                    button.Location = new Point(10 + x * j, 30+ y * i);
                    Controls.Add(button);
                }
            }
            Button plus = new Button();
            plus.Text = "+";
            plus.Size = new Size(50, 50);
            plus.Location = new Point(160, 30);
            plus.Click += new EventHandler(oper_Click);
            Controls.Add(plus);

            Button minus = new Button();
            minus.Text = "-";
            minus.Size = new Size(50, 50);
            minus.Location = new Point(210, 30);
            minus.Click += new EventHandler(oper_Click);
            Controls.Add(minus);

            Button square = new Button();
            square.Text = "х²";
            square.Size = new Size(50, 50);
            square.Location = new Point(260, 30);
            square.Click += new EventHandler(mono_Click);
            Controls.Add(square);

            Button mul = new Button();
            mul.Text = "*";
            mul.Size = new Size(50, 50);
            mul.Location = new Point(160, 80);
            mul.Click += new EventHandler(oper_Click);
            Controls.Add(mul);

            Button div = new Button();
            div.Text = "/";
            div.Size = new Size(50, 50);
            div.Location = new Point(210, 80);
            div.Click += new EventHandler(oper_Click);
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
            zero.Click += new EventHandler(number_Click);
            Controls.Add(zero);

            Button sin = new Button();
            sin.Text = "sin";
            sin.Size = new Size(50, 50);
            sin.Location = new Point(110, 180);
            sin.Click += new EventHandler(mono_Click);
            Controls.Add(sin);

            Button cos = new Button();
            cos.Text = "cos";
            cos.Size = new Size(50, 50);
            cos.Location = new Point(160, 180);
            cos.Click += new EventHandler(mono_Click);
            Controls.Add(cos);

            Button root = new Button();
            root.Text = "√";
            root.Size = new Size(50, 50);
            root.Location = new Point(210, 180);
            root.Click += new EventHandler(mono_Click);
            Controls.Add(root);
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void mono_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            calc.num1 = Double.Parse(textBox1.Text);
            textBox1.Clear();
            calc.oper = btn.Text;
            calc.Calculate();
            textBox1.Text = calc.res + "";
            clr = true;
            tochka = false;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (tochka == false)
            {
                textBox1.Text += ",";
                tochka = true;
            }
        }

        private void oper_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            calc.num1 = Double.Parse(textBox1.Text);
            textBox1.Text = "0";
            calc.oper = btn.Text;
            tochka = false;
        }

        private void result_Click(object sender, EventArgs e)
        {
            calc.num2 = Double.Parse(textBox1.Text);
            if (restwice == false)
            {
                calc.Calculate();
                last = calc.num2;
            }
            else
                calc.res += last;
            restwice = true;
            textBox1.Text = calc.res + "";
            clr = true;
            tochka = false;
        }

        private void number_Click(object sender, EventArgs e)
        {
            if (clr)
            {
                textBox1.Text = "0";
                clr = false;
            }
            Button button = sender as Button;
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text += button.Text;
        }
    }
}
