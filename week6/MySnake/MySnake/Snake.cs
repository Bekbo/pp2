using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySnake
{
    public class Snake : Objects
    {
        public char prev = 'N';
        public Snake(int x, int y, char head) : base(x, y, head){}
        public void MoveOn()
        {
            for (int i = objects.Count - 1; i > 0; i--)
            {
                objects[i].x = objects[i - 1].x;
                objects[i].y = objects[i - 1].y;
            }
        }
        enum Direction
        {
            NONE,UP,DOWN,LEFT,RIGHT
        }
        Direction direction = Direction.NONE;
        public void ChangeDirection(ConsoleKeyInfo KeyInfo)
        {
             if (objects.Count > 1)
            {
                if (KeyInfo.Key == ConsoleKey.UpArrow && prev != 'D')
                    prev = 'U';
                if (KeyInfo.Key == ConsoleKey.DownArrow && prev != 'U')
                    prev = 'D';
                if (KeyInfo.Key == ConsoleKey.LeftArrow && prev != 'R')
                    prev = 'L';
                if (KeyInfo.Key == ConsoleKey.RightArrow && prev != 'L')
                    prev = 'R';
            }
            else
            {
                if (KeyInfo.Key == ConsoleKey.UpArrow)
                    prev = 'U';
                if (KeyInfo.Key == ConsoleKey.DownArrow)
                    prev = 'D';
                if (KeyInfo.Key == ConsoleKey.LeftArrow)
                    prev = 'L';
                if (KeyInfo.Key == ConsoleKey.RightArrow)
                    prev = 'R';
            }
        }
        public void Move()
        {
            for (int i = objects.Count - 1; i > 0; i--)
            {
                objects[i].x = objects[i - 1].x;
                objects[i].y = objects[i - 1].y;
            }
            if (prev == 'U')
                objects[0].y--;
            if (prev == 'D')
                objects[0].y++;
            if (prev == 'L')
                objects[0].x--;
            if (prev == 'R')
                objects[0].x++;
        }
    }
}
