using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointClass
{
    class Point
    {
        private int x, y;

        public Point() { }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set
            {
                if(value < 100 && value > 0)
                {
                    x = value;
                }
            }
        }


        public override string ToString()
        {
            return x + " " + y;
        }
    }
}
