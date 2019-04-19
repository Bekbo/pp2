using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake.Model
{
    public class Food:Drawer
    {

        public Food(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 34);
            // TODO: is x and y on the wall?
            // TODO: is x and y on the snake?
            body[0] = new Point(x, y);
        }
    }
}
