using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintClass
{
    public enum Shape { Pencil, Line, Rectangle };

    class PaintBase
    {
        public Graphics g;
        public GraphicsPath path;
        public PictureBox picture;
        public Pen pen;
        public Bitmap btm;
        public Point prev;
        public Shape shape;

        public PaintBase(PictureBox pictureBox1)
        {
            picture = pictureBox1;
            btm = new Bitmap(picture.Width, picture.Height);
            picture.Image = btm;
            pen = new Pen(Color.Red);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            path = new GraphicsPath();
            shape = Shape.Pencil;

            picture.Paint += Picture_Paint;
        }

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
                e.Graphics.DrawPath(pen, path);
        }

        public void SaveLastPath()
        {
            if (path != null)
                g.DrawPath(pen, path);
        }

        public void Draw(Point cur)
        {
            switch (shape)
            {
                case Shape.Pencil:
                    g.DrawLine(pen, prev, cur);
                    prev = cur;
                    break;
                case Shape.Line:
                    path.Reset();
                    path.AddLine(prev, cur);
                    break;
                case Shape.Rectangle:
                    break;
            }
            picture.Refresh();
        }


        public void SaveImage(string filename)
        {
            btm.Save(filename);
        }

        // write function for file open
    }
}
