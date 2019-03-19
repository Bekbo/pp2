using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MySnake
{
    public class Food : Snake
    {
        public Food(int x, int y, char sign) : base(x, y, sign) { }
        public void Generate()
        {
            Random random = new Random();
            int x = random.Next(2, 78);
            int y = random.Next(2, 28);
            objects[0].x = x;
            objects[0].y = y;
        }
    }
}
