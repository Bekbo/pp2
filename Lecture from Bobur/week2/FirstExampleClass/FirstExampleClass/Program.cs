using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExampleClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.setFname("f name");

            Console.Write(s);

            Console.ReadKey();
        }
    }
}
