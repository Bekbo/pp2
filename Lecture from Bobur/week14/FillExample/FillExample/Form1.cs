using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillExample
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        Bitmap btm;
        Color origin, fill;
        Queue<Point> q;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Red);
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            fill = Color.Blue;
            q = new Queue<Point>();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            origin = btm.GetPixel(e.Location.X, e.Location.Y);
            q.Enqueue(e.Location);
            Fill();
        }

        public void Fill()
        {
            while(q.Count > 0)
            {
                Point cur = q.Dequeue();
                Check(cur.X, cur.Y - 1);
                Check(cur.X + 1, cur.Y);
                Check(cur.X, cur.Y + 1);
                Check(cur.X - 1, cur.Y);
            }
            pictureBox1.Refresh();

        }

        public void Check(int x, int y)
        {
            if(x > 0 && y > 0 && x < pictureBox1.Width && y < pictureBox1.Height)
            {
                if(btm.GetPixel(x, y) == origin)
                {
                    btm.SetPixel(x, y, fill);
                    q.Enqueue(new Point(x, y));
                }
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawRectangle(pen, 40, 40, 200, 200);
            pictureBox1.Refresh();
        }





    }
}
