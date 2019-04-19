using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Snake
{
    class Food
    {
        public Point location;
        public ConsoleColor color;
        public char sign;

        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(0, 80);
            int y = new Random().Next(0, 40);
            // Is "x" and "y" on the wall or on the snake? If so, regenerate new position.
            location = new Point(x, y);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}
