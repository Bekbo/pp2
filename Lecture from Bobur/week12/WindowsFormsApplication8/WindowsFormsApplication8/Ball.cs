using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication8
{
    public class Ball
    {
        public Point location;
        public SolidBrush brush;
        public Graphics g;
        public int dx, dy, wh;

        public Ball(Graphics _g, Point p)
        {
            location = new Point();
            g = _g;
            wh = 100;
            brush = new SolidBrush(Color.Red);
            location = p;
            dx = 1;
            dy = 1;
        }

        public void Move(int width, int height)
        {
            if ((location.X + wh > width) || (location.X < 0))
                dx *= -1;

            if ((location.Y + wh > height) || (location.Y < 0))
                dy *= -1;

            location.X += dx;
            location.Y += dy;
        }

        public void Draw()
        {
            g.FillEllipse(brush, location.X, location.Y, wh, wh);
        }

        public void check(List<Ball> balls)
        {
            foreach(Ball b in balls)
            {
                if(b != this)
                {
                    if (cross(b))
                    {
                        dx *= -1;
                        dy *= -1;

                        b.dx *= -1;
                        b.dy *= -1;
                    }
                }
            }
        }

        public bool cross(Ball b)
        {
            if ((location.X + wh == b.location.X) || (b.location.X + wh == location.X))
                return true;
            return false;
        }
    }
}
