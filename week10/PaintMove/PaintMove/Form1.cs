using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintMove
{
    public partial class Form1 : Form
    {
        public enum Shape { None, Rectangle, Circle,Tri };
        public Shape shape = Shape.None;
        public Graphics g;
        public Bitmap btm;
        public Pen pen;
        public Point p,p1, p2;
        public bool draw = false;
        public List<objects> list;
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            p = new Point(200, 200);
            pen = new Pen(Color.Black);
            list = new List<objects>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            if (p1.X >= p.X && p1.Y >= p.Y && p1.X <=p.X +50 && p1.Y <= p.Y + 50)
            {
                draw = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            shape = Shape.Tri;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            shape = Shape.Rectangle;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            shape = Shape.Circle;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            shape = Shape.None;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen2 = new Pen(Color.White);
            draw = false;
                switch (shape)
                {
                    case Shape.None:
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (p1.X <= list[i].start.X + list[i].widthx &&
                                p1.X >= list[i].start.X && p1.Y <= list[i].start.Y + list[i].widthy &&
                                p1.Y >= list[i].start.Y)
                            {
                                pen2 = new Pen(Color.White);
                                if (list[i].shapename == "Rectangle")
                                {
                                    g.DrawRectangle(pen2, list[i].start.X, list[i].start.Y, list[i].widthx, list[i].widthy);
                                }
                                else
                                {
                                    g.DrawEllipse(pen2, list[i].start.X, list[i].start.Y, list[i].widthx, list[i].widthy);
                                }
                                list[i].start = p2;
                                if (list[i].shapename == "Rectangle")
                                {
                                    g.DrawRectangle(pen, list[i].start.X, list[i].start.Y, list[i].widthx, list[i].widthy);
                                }
                                if (list[i].shapename == "Circle")
                                {
                                    g.DrawEllipse(pen, list[i].start.X, list[i].start.Y, list[i].widthx, list[i].widthy);
                                }
                            }
                        }
                    break;
                    case Shape.Rectangle:
                        g.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                        objects object1 = new objects();
                        object1.shapename = "Rectangle";
                        object1.start = p1;
                        object1.widthx = p2.X - p1.X;
                        object1.widthy = p2.Y - p1.Y;
                        list.Add(object1);
                    break;
                    case Shape.Circle:
                        g.DrawEllipse(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
                        objects object2 = new objects();
                        object2.shapename = "Circle";
                        object2.start = p1;
                        object2.widthx = p2.X - p1.X;
                        object2.widthy = p2.Y - p1.Y;
                        list.Add(object2);
                    break;
            }
            pictureBox1.Refresh();
        }
    }
}
