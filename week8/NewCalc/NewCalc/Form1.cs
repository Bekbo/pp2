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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            plus.Click += new EventHandler(number_Click);
            Controls.Add(plus);

            Button bclear = new Button();
            bclear.Text = "C";
            bclear.Size = new Size(50, 50);
            bclear.Location = new Point(160, 80);
            bclear.Click += new EventHandler(bclear_Click);
            Controls.Add(bclear);
        }
        private void bclear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void number_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }
        
    }
}
