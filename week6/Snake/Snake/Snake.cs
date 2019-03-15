using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake:GameObject
    {
        enum Direction
        {
            None,
            Right,
            Left,
            Down,
            UP
        }
        Direction direction = Direction.None;
        public Snake(int x ,int y, char sign , ConsoleColor color) :base(x, y, sign, color)
        {
        }

        public void Move(ConsoleKeyInfo keyInfo)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
                body[0].y--;
            if (keyInfo.Key == ConsoleKey.DownArrow)
                body[0].y++;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                body[0].x--;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                body[0].x++;
        }
    }
}
