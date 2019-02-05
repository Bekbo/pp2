using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static int f(int n)
        {
            int prime = 1;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    prime = 0;
            }
            return prime;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("in.txt");
            string ss = sr.ReadToEnd();
            StreamWriter sw = new StreamWriter("out.txt");
            string[] arr = ss.Split();
            for (int i = 0; i < arr.Length; i++)
            {
                if (f(int.Parse(arr[i])) == 1)
                {
                    sw.Write(arr[i] + " ");
                }
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}