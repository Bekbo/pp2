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

namespace gitExample2
{
public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap;
        Graphics g;
        Point prev;
        Point here;
        Pen pp;
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            pp = new Pen(Color.Red);
        }
        bool draw = false;
        int x, y, r = 1;
        Color[] colors = new Color[] { Color.Red, Color.Plum, Color.PowderBlue, Color.Purple, Color.RoyalBlue };
        Random random = new Random();

            private void timer1_Tick(object sender, EventArgs e)
                {
                Brush brush = Brushes.Black;
                GraphicsPath graphPath = new GraphicsPath();
                Font font = new Font("Times New Roman", 12F, FontStyle.Bold);
                //g.Clear(DefaultBackColor);
                    r += 2;
                    Point p = new Point(x,y);
                    Point start = new Point(100, 100);
                    Point control1 = new Point(200, 10);
                    Point control2 = new Point(350, 50);
                    Point end = new Point(500, 100);
                Point p1 = new Point(x,y-50); Point p2 = new Point(x-50,y+50); Point p3 = new Point(x+50,y+50);
                Point[] pts = new Point[] {start,control1,control2,end};
                        int index = random.Next(0, colors.Length - 1);
                Point[] ps = new Point[] { p1, p2, p3 };
                Pen pen = new Pen(colors[index], 5);
                graphPath.AddPolygon(ps);
                //graphPath.AddEllipse(x - r, y - r, r * 2, r * 2);
                graphPath.AddCurve(pts);

                //g.Save();

                Region re = new Region(graphPath);
                //g.FillRegion( Brushes.Red , re);
            
                //g.FillPath(brush, graphPath);

                string s = "Bekbolat";
                //g.DrawString(s, font, brush, x-30,y-10);
                //g.DrawPolygon(pen,ps);

                //g.DrawPie(pen,x-50,y-50,100,100,0,270);

                    //g.DrawPath(pen, graphPath);
                    //g.DrawLines(pen, pts);
                    //g.DrawLine(pen, start, end);
                    Image image = Image.FromFile("bubble.png");
                    //g.DrawImage(image,x-image.Width/2,y-image.Height/2);
                    Icon icon = new Icon("ico.ico");
                    //g.DrawIcon(icon, x - icon.Width/2, y - icon.Height/2);
            
                    //g.DrawClosedCurve(pen, pts);    
            
                    //g.DrawBeziers(pen, pts);
            
                    //g.DrawBezier(pen, start, control1, control2, end);
            
                    //g.DrawArc(pen, x-r , y-r , r , r , 0, 270);
            
                    //g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
                    pictureBox1.Refresh();
                }

            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (draw)
                {
                    here = e.Location;
                    g.DrawLine(pp,prev,here);
                Pen pen = new Pen(Color.Red);
                g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
                prev = here;
                    pictureBox1.Refresh();
                }
            }

            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                    x = e.Location.X;
                    y = e.Location.Y;
                    r = 1;
                if (e.Button == MouseButtons.Left)
                {
                    prev = e.Location;
                    draw = true;
                }
                string s;
            timer1.Start();
            }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }
    }
}
