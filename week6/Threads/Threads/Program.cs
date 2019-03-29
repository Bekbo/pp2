using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    class Program
    {
        public static int i = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(thread1);
            Thread t2 = new Thread(thread1);
            t1.Name = "thread 1 ";
            t2.Name = "thread 2 ";
            t1.Start();
            t2.Start();
            Console.WriteLine(t1.ThreadState + " and " + t2.ThreadState);
            Console.ReadKey();
        }

        public static void thread1()
        {
            for (i = i; i < i + 1; i++)
            {
                Console.WriteLine(Thread.GetDomain().FriendlyName + " " + Thread.CurrentThread.Name + " " + Thread.CurrentThread.Name + " " + i);
                Console.WriteLine();
            }
        }
    }
}
