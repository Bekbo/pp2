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

namespace TryToPaintNo
{
    public partial class Form1 : Form
    {
        public enum Shape { None, Pencil, Rectangle, Circle, Line, Cleaner, Fill, Star, RightTri, Tri };
        public Graphics g;
        public Bitmap btm;
        public Pen pen;
        public Shape shape = Shape.None;
        public bool startdraw = false;
        public Point prev,end;
        public GraphicsPath graphicsPath;

        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
            pen = new Pen(Color.Black);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            graphicsPath = new GraphicsPath();
            //pictureBox1.Paint += Picture_Paint;
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startdraw = true;
            prev = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.Location;
            label1.Text = e.Location.X + " " + e.Location.Y;
            pen.Width = trackBar1.Value;
            if (startdraw)
            {
                switch (shape)
                {
                    case Shape.None:
                        break;
                    case Shape.Pencil:
                        g.DrawLine(pen, prev, e.Location);
                        prev = e.Location;
                        break;
                    case Shape.Cleaner:
                        int ww = trackBar1.Value;
                        Pen pp = new Pen(Color.White, ww);
                        g.DrawRectangle(pp, e.Location.X - ww/2, e.Location.Y - ww/2, ww, ww);
                        break;
                    default:
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            shape = Shape.Pencil;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            end = e.Location;
            Point p1, p2, p3, p4, p5;
            Point[] points;
            if (startdraw)
            {
                switch (shape)
                {
                    case Shape.None:
                        break;
                    case Shape.Pencil:
                        break;
                    case Shape.Circle:
                        g.DrawEllipse(pen, prev.X, prev.Y, e.Location.X - prev.X, e.Location.Y - prev.Y);
                        break;
                    case Shape.Rectangle:
                        Rectangle res = new Rectangle();
                        res.X = Math.Min(e.Location.X, prev.X);
                        res.Y = Math.Min(e.Location.Y, prev.Y);
                        res.Width = Math.Abs(prev.X - e.Location.X);
                        res.Height = Math.Abs(prev.Y - e.Location.Y);
                        g.DrawRectangle(pen, res);
                        break;
                    case Shape.Line:
                        g.DrawLine(pen, prev, e.Location);
                    break;
                    case Shape.Cleaner:
                        int ww = trackBar1.Value;
                        Pen pp = new Pen(Color.White, ww);
                        g.DrawRectangle(pp, e.Location.X - ww/2, e.Location.Y - ww/2, ww, ww);
                        break;
                    case Shape.Fill:
                        Fill(e.Location, pen.Color);
                        break;
                    case Shape.Star:
                        if (prev.X <= e.Location.X)
                        {
                            p1 = new Point((prev.X + e.Location.X) / 2, prev.Y);
                            p2 = new Point(prev.X, (prev.Y + e.Location.Y) / 2);
                            p3 = new Point(e.Location.X, (prev.Y + e.Location.Y) / 2);
                            p4 = new Point(prev.X + Math.Abs(prev.X - e.Location.X) / 5, e.Location.Y);
                            p5 = new Point(prev.X + Math.Abs(prev.X - e.Location.X) * 4 / 5, e.Location.Y);
                        }
                        else
                        {
                            end = prev;
                            prev = e.Location;
                            p1 = new Point((prev.X + end.X) / 2, prev.Y);
                            p2 = new Point(prev.X, (prev.Y + end.Y) / 2);
                            p3 = new Point(end.X, (prev.Y + end.Y) / 2);
                            p4 = new Point(prev.X + Math.Abs(prev.X - end.X) / 5, end.Y);
                            p5 = new Point(prev.X + Math.Abs(prev.X - end.X) * 4 / 5, end.Y);
                        }
                        //points = new Point[3] { p1, p4, p3};
                        //g.FillPolygon(Brushes.Red, points);
                        //points = new Point[3] { p2, p5, p1 };
                        points = new Point[6] { p1,p4,p3,p2, p5, p1 };
                        //g.FillPolygon(Brushes.Red, points);
                        //graphicsPath.AddLines(points);
                        //g.FillPath(Brushes.Red, graphicsPath);
                        g.DrawLines(pen, points);
                        break;
                    case Shape.Tri:
                        p1 = new Point((e.Location.X + prev.X) / 2, prev.Y);
                        p2 = new Point(e.Location.X, e.Location.Y);
                        p3 = new Point(prev.X, e.Location.Y);
                        points = new Point[3] { p1, p2, p3 };
                        g.DrawPolygon(pen, points);
                        break;
                    case Shape.RightTri:
                        p1 = new Point(prev.X, e.Location.Y);
                        p2 = new Point(e.Location.X, e.Location.Y);
                        p3 = new Point(prev.X, prev.Y);
                        points = new Point[3] { p1, p2, p3 };
                        g.DrawPolygon(pen, points);
                        break;
                    default:
                        break;
                }
                pictureBox1.Refresh();
                startdraw = false;
            }
        }

        private void Fill(Point cur, Color color)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                btm.Save(saveFileDialog1.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                btm = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = btm;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            shape = Shape.Fill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            shape = Shape.Cleaner;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            shape = Shape.Line;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            shape = Shape.Rectangle;
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point p1, p2, p3, p4, p5, p6;
            switch (shape)
                {
                    case Shape.Circle:
                        e.Graphics.DrawEllipse(pen, prev.X, prev.Y, end.X - prev.X, end.Y - prev.Y);
                        break;
                    case Shape.Rectangle:
                        e.Graphics.DrawRectangle(pen, prev.X, prev.Y, end.X - prev.X, end.Y - prev.Y);
                        break;
                    case Shape.Line:
                        e.Graphics.DrawLine(pen, prev, end);
                        break;
                    case Shape.Cleaner:
                        int ww = trackBar1.Value;
                        Pen pp = new Pen(Color.White, ww);
                        e.Graphics.DrawRectangle(pp, end.X - ww / 2, end.Y - ww / 2, ww, ww);
                        break;
                    case Shape.Fill:
                        Fill(end, pen.Color);
                        break;
                    case Shape.Star:
                        if (prev.X <= end.X)
                        {
                            p1 = new Point((prev.X + end.X) / 2, prev.Y);
                            p2 = new Point(prev.X, (prev.Y + end.Y) / 2);
                            p3 = new Point(end.X, (prev.Y + end.Y) / 2);
                            p4 = new Point(prev.X + Math.Abs(prev.X - end.X) / 5, end.Y);
                            p5 = new Point(prev.X + Math.Abs(prev.X - end.X) * 4 / 5, end.Y);
                        }
                        else
                        {
                            Point end2 = prev;
                            prev = end;
                            p1 = new Point((prev.X + end2.X) / 2, prev.Y);
                            p2 = new Point(prev.X, (prev.Y + end2.Y) / 2);
                            p3 = new Point(end2.X, (prev.Y + end2.Y) / 2);
                            p4 = new Point(prev.X + Math.Abs(prev.X - end2.X) / 5, end2.Y);
                            p5 = new Point(prev.X + Math.Abs(prev.X - end2.X) * 4 / 5, end2.Y);
                        }
                        Point[] points = new Point[6] { p1, p4, p3, p2, p5, p1 };
                        e.Graphics.DrawLines(pen, points);
                        break;
                    case Shape.Tri:
                        p1 = new Point((end.X + prev.X) / 2, prev.Y);
                        p2 = new Point(end.X, end.Y);
                        p3 = new Point(prev.X, end.Y);
                        points = new Point[3] { p1, p2, p3 };
                        e.Graphics.DrawPolygon(pen, points);
                        break;
                    case Shape.RightTri:
                        p1 = new Point(prev.X, end.Y);
                        p2 = new Point(end.X, end.Y);
                        p3 = new Point(prev.X, prev.Y);
                        points = new Point[3] { p1, p2, p3 };
                        e.Graphics.DrawPolygon(pen, points);
                        break;
                default:
                    break;
                }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            shape = Shape.Star;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            shape = Shape.RightTri;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            shape = Shape.Tri;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            DialogResult colorRes = colorDialog1.ShowDialog();
            if (colorRes == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/obek9/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            shape = Shape.Circle;
        }
    }
}
