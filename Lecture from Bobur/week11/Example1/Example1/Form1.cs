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

namespace Example1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics(); // e.Graphics
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            //g.DrawLine(Pens.Red, 10, 10, 100, 100);
            //g.DrawRectangle(pen, 10, 10, 100, 50);
            //g.DrawEllipse(pen, 10, 150, 100, 200);
            Point[] points =
            {
                new Point(100, 100),
                new Point(150, 150),
                new Point(50, 150),
                new Point(100, 100)
            };
            //g.DrawPolygon(pen, points);

            //g.DrawCurve(pen, points);

            //g.DrawArc(pen, 10, 10, 100, 100, 0, 359);

            GraphicsPath path = new GraphicsPath();

            path.AddLine(100, 100, 10, 100);

            Rectangle r = new Rectangle(30, 30, 100, 100);
            path.AddRectangle(r);

            g.DrawPath(pen, path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Red);

            //g.FillRectangle(brush, 10, 10, 100, 100);
            Font f = new Font(FontFamily.GenericSerif, 30);
            g.DrawString("hello!", f, brush, 10, 10);

        }
    }
}
