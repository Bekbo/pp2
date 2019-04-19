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

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private GraphicsPath path;
        private Pen pen;
        private Bitmap btm;
        private Point prev;

        public Form1()
        {
            InitializeComponent();

            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            pen = new Pen(Color.Red);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            path = new GraphicsPath();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point cur = e.Location;
            if(e.Button == MouseButtons.Left)
            {
                path.Reset();
                path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(path != null)
                e.Graphics.DrawPath(pen, path);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (path != null)
                g.DrawPath(pen, path);
        }
    }
}
