using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("in.txt");
            string ss = sr.ReadToEnd();
            bool pol = true;
            char[] arr = ss.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                // Console.WriteLine(arr[i], arr[arr.Length - 1]);
                if (arr[i] != arr[arr.Length - 1 - i])
                    pol = false;
            }
            if (pol == false)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES ");
            Console.ReadKey();
        }
    }
}
 