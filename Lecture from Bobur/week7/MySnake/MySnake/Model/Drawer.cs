using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    public class Drawer
    {
        public ConsoleColor color;
        public List<Point> body = new List<Point>();
        public char sign;

        public Drawer() { } 

        public Drawer(ConsoleColor color, char sign, List<Point> body)
        {
            this.body = body;
            this.color = color;
            this.sign = sign;
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

        // TODO: The Save function (Serialization)
        // TODO: The Resume function (Deserialization)
    }
}
