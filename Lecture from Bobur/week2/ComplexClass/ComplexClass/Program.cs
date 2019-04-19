using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(2, 3);            
            Complex b = new Complex(3, 4);
            Complex c = a + b;


            Console.Write(c);

            Console.ReadKey();
        }
    }
}
