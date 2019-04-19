using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PaintNo1
{
    public enum Shape { None, Pencil, Rectangle, Circle, Line, Cleaner, Fill };

    class painter
    {
        public Graphics g;
        public GraphicsPath path = new GraphicsPath();
        public Bitmap btm;
        public PictureBox picture;
        public Shape shape = Shape.None;
        public Pen pen;

        public bool startdraw = false;
        public Point prev;

        public painter(Shape shape)
        {
            this.shape = shape;
        }
        
        public painter(PictureBox p)
        {
            this.picture = p;
            btm = new Bitmap(p.Width, p.Height);
            g = Graphics.FromImage(btm);
            p.Image = btm;
            pen = new Pen(Color.Red);
            picture.Paint += Picture_Paint;
        }

        public void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        public void Draw(Point curr)
        {
            switch (shape)
            {
                case Shape.Pencil:
                    g.DrawLine(pen, prev, curr);
                    prev = curr;
                    break;
                case Shape.Rectangle:
                    path = new GraphicsPath();
                    path.AddRectangle(new Rectangle(prev.X, prev.Y, curr.X - prev.X, curr.Y - prev.Y));
                    break;
                case Shape.Circle:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle(prev.X, prev.Y, curr.X - prev.X, curr.Y - prev.Y));
                    break;
                case Shape.Line:
                    path = new GraphicsPath();
                    path.AddLine(prev, curr);
                    break;
                case Shape.None:
                    break;
                case Shape.Cleaner:

                    break;
                case Shape.Fill:

                    break;
            }
            picture.Refresh();
        }
    }
}
