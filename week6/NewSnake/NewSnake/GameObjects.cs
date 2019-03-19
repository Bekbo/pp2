using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSnake
{
    public class GameObjects
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public GameObjects() { }
        public GameObjects(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point> { new Point(x, y) };
            this.sign = sign;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                Console.ForegroundColor = color;
            }
        }

        public bool IsColl(GameObjects obj)
        {
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }

        public bool IsCollitself(GameObjects obj)
        {
            for (int i = 1; i < obj.body.Count; i++)
            {
                if (obj.body[i].x == obj.body[0].x && obj.body[i].y == obj.body[0].y)
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(' ');
            }
        }
    }
}
