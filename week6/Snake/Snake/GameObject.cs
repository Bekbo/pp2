using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameObject
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public GameObject(int x, int y , char sign, ConsoleColor color)
        {
            body = new List<Point>();
            Point p = new Point(x, y);
            body.Add(p);
            this.sign = sign;
            this.color = color;
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

        public bool IsColl(GameObject obj)
        {
            foreach(Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
    }
}
