using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewnewCalc
{
    public partial class Form1 : Form
    {
        CalcBase calc;
        public bool clr, tochka = false, restwice = false;
        public double last = 0,memory=0;
        public Form1()
        {
            InitializeComponent();
            output.Height = 42;
            calc = new CalcBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] btns = { "MS", "MR", "MC", "M+", "M-",
                "←","CE" , "C", "±" , "√",
                "7","8","9","/","%",
                "4","5","6","*","1/x",
                "1","2","3","-","х²",
                "0",",","n!","+","="
                };

            int k = 0;
            int x = 40, y = 40;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Text = btns[k];
                    button.Font = new Font("Times New Roman", 9F, FontStyle.Regular,GraphicsUnit.Point, 204);
                    k++;
                    button.Size = new Size(35, 35);
                    if (i == 0)
                    {
                        button.Click += new EventHandler(memory_Click);
                    }
                    if (i == 1 && j < 3)
                    {
                        button.Click += new EventHandler(textboxchange_Click);
                    }
                    if (i==1 && j>2 || i==3 && j==4 || i==4 && j==4 || i==5 &&j==2)
                    {
                        button.Click += new EventHandler(monooper_Click);
                    }
                    if (i==2 && j<3 || i==3 && j<3 || i==4 && j < 3 || i==5 && j==0)
                    {
                        button.Click += new EventHandler(number_Click);
                    }
                    if (i==2 && j>2 || i==3 && j==3 || i==4 && j==3 || i==5 && j == 3)
                    {
                        button.Click += new EventHandler(oper_Click);
                    }
                    if (i == 5 && j == 1)
                    {
                        button.Click += new EventHandler(dot_Click);
                    }
                    if (i == 5 && j == 4)
                    {
                        button.Click += new EventHandler(result_Click);
                    }
                    button.BackColor = Color.DeepSkyBlue;
                    button.MouseEnter += new EventHandler(button_MouseEnter);
                    button.MouseLeave += new EventHandler(button_MouseLeave);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Location = new Point(25 + x * j, 55 + y * i);
                    Controls.Add(button);
                }
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button temp = sender as Button;
            temp.BackColor = Color.LightYellow;
            temp.FlatAppearance.BorderSize = 1;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button temp = sender as Button;
            temp.BackColor = Color.DeepSkyBlue;
            temp.FlatAppearance.BorderSize = 0;
        }

        private void memory_Click(object sender, EventArgs e)
        {
            restwice = false;
            Button btn = (Button) sender;
            calc.oper = btn.Text;
            double result = 0;
            switch (calc.oper)
            {
                case "MC":
                    memory = 0;
                    break;
                case "MR":
                    output.Text = memory+"";
                    break;
                case "MS":
                    memory = Double.Parse(output.Text);
                    output.Text = "0";
                    break;
                case "M+":
                    result = memory + Double.Parse(output.Text);
                    memory = result;
                    output.Text = result + "";
                    break;
                case "M-":
                    result = memory - Double.Parse(output.Text);
                    output.Text = result + "";
                    memory = result;
                    break;
            }
        }

        private void textboxchange_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            calc.oper = btn.Text;
            switch (calc.oper)
            {
                case "←":
                    if (output.Text.Length != 1)
                        output.Text = output.Text.Substring(0, output.Text.Length - 1);
                    else
                        output.Text = "0";
                    break;
                case "CE":
                    output.Text = "0";
                    break;
                case "C":
                    output.Text = "0";
                    memory = 0;
                    tochka = false;
                    restwice = false;
                    clr = false;
                    break;
            }
        }

        private void oper_Click(object sender, EventArgs e)
        {
            restwice = false;
            Button btn = (Button)sender;
            calc.num1 = Double.Parse(output.Text);
            output.Text = "0";
            calc.oper = btn.Text;
            tochka = false;
        }

        private void monooper_Click(object sender, EventArgs e)
        {
            restwice = false;
            Button btn = (Button)sender;
            calc.num1 = Double.Parse(output.Text);
            output.Clear();
            calc.oper = btn.Text;
            calc.Calculate();
            output.Text = calc.res + "";
            clr = true;
            tochka = false;
        }

        private void number_Click(object sender, EventArgs e)
        {
            restwice = false;
            if (clr)
            {
                output.Text = "0";
                clr = false;
            }
            Button button = sender as Button;
            if (output.Text == "0")
                output.Text = "";
            output.Text += button.Text;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (tochka == false)
            {
                output.Text += ",";
                tochka = true;
            }
        }

        private void result_Click(object sender, EventArgs e)
        {
            calc.num2 = Double.Parse(output.Text);
            if (restwice == false)
            {
                calc.Calculate();
                last = calc.num2;
            }
            else
            {
                calc.num1 = last;
                last = calc.num2;
                calc.num2 = calc.num1;
                calc.num1 = last;
                calc.Calculate();
                last = calc.num2;
            }
            restwice = true;
            output.Text = calc.res + "";
            clr = true;
            tochka = false;
        }
    }
}
