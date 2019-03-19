using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSnake
{
    public class Snake : GameObjects
    {
        public string dir;
        public Snake() { }
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color) { }

        public void Goo(ConsoleKeyInfo key)
        {
            if (body.Count > 1)
            {
                if (key.Key == ConsoleKey.UpArrow && dir != "DOWN")
                    dir = "UP";
                if (key.Key == ConsoleKey.DownArrow && dir != "UP")
                    dir = "DOWN";
                if (key.Key == ConsoleKey.LeftArrow && dir != "RIGHT")
                    dir = "LEFT";
                if (key.Key == ConsoleKey.RightArrow && dir != "LEFT")
                    dir = "RIGHT";
            }
            else
            {
                if (key.Key == ConsoleKey.UpArrow)
                    dir = "UP";
                if (key.Key == ConsoleKey.DownArrow)
                    dir = "DOWN";
                if (key.Key == ConsoleKey.LeftArrow)
                    dir = "LEFT";
                if (key.Key == ConsoleKey.RightArrow)
                    dir = "RIGHT";
            }
        }

        public void Move()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            if (dir == "UP")
                body[0].y--;
            if (dir == "DOWN")
                body[0].y++;
            if (dir == "LEFT")
                body[0].x--;
            if (dir == "RIGHT")
                body[0].x++;
        }
    }
}
