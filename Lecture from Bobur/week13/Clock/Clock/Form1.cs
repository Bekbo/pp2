using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        Graphics g;
        float radius = 100;
        Pen pen;
        Point center, end;
        GraphicsPath path;
        double deg;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;

            g = this.CreateGraphics();
            pen = new Pen(Color.Red, 3);
            center = new Point(200, 200);
            path = new GraphicsPath();

            end = new Point(200, 100);
            deg = 270;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double a = radius * Math.Sin(deg * Math.PI / 180);
            double b = radius * Math.Cos(deg * Math.PI / 180);

            end.X = center.X + (int)b;
            end.Y = center.Y + (int)a;

            deg += 6;
            if (deg == 360)
                deg = 0;

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawEllipse(pen, 100, 100, radius*2, radius*2);

            path.Reset();
            path.AddLine(center.X, center.Y, end.X, end.Y);

            g.DrawPath(pen, path);
        }
    }
}
