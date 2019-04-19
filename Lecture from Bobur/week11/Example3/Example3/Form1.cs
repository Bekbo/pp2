using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            brush = new SolidBrush(Color.Red);

            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (brush.Color == Color.Red)
                brush.Color = Color.Blue;
            else
                brush.Color = Color.Red;

            //brush.Color = brush.Color == Color.Red ? Color.Blue : Color.Red;


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillRectangle(brush, 0, 0, this.Width, this.Height);
        }
    }
}
