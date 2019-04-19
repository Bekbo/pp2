using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            s.Push(2); 
            s.Push(3);
            s.Push(4);
            //s.Pop();
            Console.WriteLine("Stack size: {0}, last added element is: {1}", s.Count, s.Peek());
            /*
            foreach(int i in s)
            {
                Console.WriteLine(i);
            }
            */

            Console.ReadKey();
        }
    }
}
