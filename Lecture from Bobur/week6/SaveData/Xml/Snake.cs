using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml
{
    public class Snake
    {
        public char sign;
        public ConsoleColor color;

        public Snake() { }

        public Snake(char s, ConsoleColor c)
        {
            sign = s;
            color = c;
        }

        public override string ToString()
        {
            return sign + " " + color.ToString();
        }

    }
}
