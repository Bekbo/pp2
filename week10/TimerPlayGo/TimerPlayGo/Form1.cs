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

namespace TimerPlayGo
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public Bitmap btm;
        public Pen pen;
        public Point start, end;
        public GraphicsPath graphicsPath;
        public int r = 20;
        public bool draw = false;
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            graphicsPath = new GraphicsPath();
            pen = new Pen(Color.Red, 1);
            pictureBox1.Image = btm;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            draw = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point aa = new Point(start.X, start.Y);
            Point bb = new Point(end.X, start.Y);
            Point cc = new Point(end.X, end.Y);
            Point[] norm = new Point[3] { aa, bb, cc };
            e.Graphics.DrawPolygon(pen, norm);
            //e.Graphics.DrawEllipse(pen, end.X - start.X, end.Y - start.Y, end.X - start.X, end.Y - start.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.Location;
            if (draw)
            {
                //g.FillPath(Brushes.Red, graphicsPath);
                //pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Point p1 = new Point();
                Point p2 = new Point();
                Point p3 = new Point();
                Point a = new Point();
                p1.Y = start.Y + 150; p1.X = start.X;
                a.X = start.X - 100; a.Y = start.Y + 100; end.X = start.X + 100; end.Y = a.Y;
                p2.X = a.X;p2.Y = a.Y - 150;p3.X = end.X;p3.Y = end.Y - 150;
                start.Y -= 100;
                Point b = new Point();
                Point[] ps = new Point[3] { p2, p1, p3 };
                Point[] points = new Point[3] { start, a, end };
                //graphicsPath.AddEllipse(start.X - r, start.Y - r, r * 2, 2 * r);
                //g.DrawEllipse(pen, end.X - start.X, end.Y - start.Y, end.X - start.X, end.Y - start.Y);
                //graphicsPath.AddPolygon(points);
                graphicsPath.AddPolygon(points);
                graphicsPath.AddPolygon(ps);
                //g.FillPolygon(Brushes.Blue, ps);
                //g.FillPolygon(Brushes.Red, points);
                Point aa = new Point(start.X, start.Y);
                Point bb = new Point(end.X, start.Y);
                Point cc = new Point(end.X, end.Y);
                Point[] norm = new Point[3] { aa,bb,cc};
                g.DrawPolygon(pen, norm);
                //g.DrawPolygon(pen, ps);
                //g.DrawPath(pen, graphicsPath);
                //g.DrawPolygon(pen, points);
                //g.DrawPolygon(pen, ps);
                g.FillPath(Brushes.Red, graphicsPath);
                pictureBox1.Refresh();
                draw = false;
            }

        }
    }
}
