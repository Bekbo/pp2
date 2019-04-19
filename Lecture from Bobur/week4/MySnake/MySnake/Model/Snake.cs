using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    public class Snake
    {
        public List<Point> body;
        public ConsoleColor color;
        public char sign;


        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            body.Add(new Point(9, 10));
            body.Add(new Point(8, 10));
            body.Add(new Point(7, 10));
            body.Add(new Point(6, 10));
            color = ConsoleColor.Yellow;
            sign = 'o';
        }


        public void move(int dx, int dy)
        {
            for(int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;
            
        }

        public void draw()
        {
            Console.Clear();
            int i = 0;
            foreach(Point p in body)
            {
                Console.ForegroundColor = (i == 0) ? ConsoleColor.Red : color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                i++;
            }
        }
    }
}
