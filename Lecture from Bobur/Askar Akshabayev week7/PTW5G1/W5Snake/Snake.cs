using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace W5Snake
{
    class Snake
    {
        public List<Point> body;
        public char sign = '*';
        public ConsoleColor color;

        public Snake()
        {
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Yellow;
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;
            if (body[0].x > Console.WindowWidth)
                body[0].x = 0;
            if (body[0].x < 0)
                body[0].x = Console.WindowWidth;

            if (body[0].y > Console.WindowHeight )
                body[0].y = 0;
            if (body[0].y < 0)
                body[0].y = Console.WindowHeight;

            CollisionWithWallAndSnake();
            Eat();
        }

        public void CollisionWithWallAndSnake()
        {
            // think and try to remember code :)
        }

        public void Eat()
        {
            // think and try to remember code :)
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
