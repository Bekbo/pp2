using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PaintMove
{
    public class objects
    {
        public string shapename;
        public Point start;
        public int widthx,widthy;

        public objects() { }

        public objects(string shapename, Point start, int widthx, int widthy)
        {
            this.shapename = shapename;
            this.start = start;
            this.widthx = widthx;
            this.widthy = widthy;
        }
    }
}
