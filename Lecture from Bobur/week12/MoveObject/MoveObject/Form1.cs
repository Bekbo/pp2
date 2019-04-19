using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveObject
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush;
        int x = 0, dx = 10;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            brush = new SolidBrush(Color.Red);
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillEllipse(brush, x, 100, 100, 100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x + 100 > Width)
                dx = -10;
            else if (x < 0)
                dx = 10;

            x += dx;

            Refresh();
        }
    }
}
