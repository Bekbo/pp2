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
        public static int f(int n) // function to check the number for prime
        {
            int prime = 1; // like boolean, prime true
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) // if num divides into at least one number,
                    prime = 0; // it is not prime
            }
            return prime;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("in.txt"); // the input file
            string ss = sr.ReadToEnd(); // insert the file strings to one string
            StreamWriter sw = new StreamWriter("out.txt"); // output file
            string[] arr = ss.Split(); // array of chars (or numbers)
            for (int i = 0; i < arr.Length; i++)
            {
                if (f(int.Parse(arr[i])) == 1) // if prime test of each number in the array is ==1
                {
                    sw.Write(arr[i] + " "); // write the num into the outpul file
                }
            }
            sw.Close(); // close the file
            Console.ReadKey();
        }
    }
}