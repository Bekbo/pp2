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

namespace Draw
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public Bitmap btm;
        public Pen pen; 
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            pen = new Pen(Color.Red);
        }
        public bool draw = false;
        Point start,end;
        string dir;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            end = e.Location;
            Point p1 = new Point(start.X, start.Y);
            Point p2 = new Point(start.X+100, start.Y+100);
            Point p3 = new Point(start.X, start.Y+100);
            Point[] ps = new Point[3] {p1,p2,p3 };
            //g.DrawEllipse(pen, start.X, start.Y, 100, 100);
            pictureBox1.Refresh();
            //dir = "R";
            timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p1 = new Point(start.X, start.Y);
            Point p2 = new Point(start.X + 100, start.Y + 100);
            Point p3 = new Point(start.X, start.Y + 100);
            Point[] ps = new Point[3] { p1, p2, p3 };
            g.DrawEllipse(pen, start.X, start.Y, 100, 100);
            Point p4 = new Point(start.X + 100, start.Y);
            ps = new Point[4] { p1, p2, p3, p4 };
            pictureBox1.Refresh();
        }

        private string Bin(int n)
        {
            string s="";
            string sre = "";
            while (n > 0)
            {
                s += n % 2 + "";
                n /= 2;
            }
            for (int i = s.Length - 1; i > -1; i--)
            {
                 sre+= s[i];
            }
            return sre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            textBox1.Text = Bin(n);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }


    }
}
