using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    public class Snake : Drawer
    {
        public Snake(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body) { }

        public void Move(int dx, int dy)
        {
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            // TODO: can snake eat?
            // TODO: check for collision with wall 
            // TODO: check for collision with itself (snake)
            // TODO: check for collision with border (console border (maximum width and height))
            // TODO: if necessary load new level wall
        }

        public bool CanEat(Food f)
        {
            if(body[0].x == f.body[0].x && body[0].y == f.body[0].y)
            {
                body.Add(new Point(f.body[0].x, f.body[0].y)); 
                return true;
            }
            return false;
        }

    }
}
