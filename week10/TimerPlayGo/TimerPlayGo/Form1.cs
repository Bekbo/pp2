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
        public Point start, end,p;
        public GraphicsPath graphicsPath;
        public int r = 20;
        public bool draw = false;
        public int vx,vy, t=0;
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            graphicsPath = new GraphicsPath();
            pen = new Pen(Color.Red, 1);
            pictureBox1.Image = btm;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = t + " " + p.X + " " + p.Y + " " + vx + " " + vy;
            p.X = p.X - vx * t;
            p.Y = p.Y - vy * t + t * t / 2;
            g.Clear(Color.White);
            pictureBox1.Refresh();
            g.DrawEllipse(pen, p.X, p.Y, 50, 50);
            pictureBox1.Refresh();
            t++;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            draw = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

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

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            vx = end.X - start.X;
            vy = end.Y - start.Y;
            p = end;
            if (draw)
            {
                g.DrawEllipse(pen, p.X,p.Y, 50,50);
                pictureBox1.Refresh();
                timer1.Enabled = true;
            }

        }
    }
}
