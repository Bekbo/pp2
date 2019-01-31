using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0, a = int.Parse(Console.ReadLine()); // Reading the size (first row)
            string[] arr = Console.ReadLine().Split(); // Reading an array with given size
            string ss = ""; // null string
            for (int j = 0; j < a; j++)  // Run through elements of array
            {
                int n = int.Parse(arr[j]);     // converting to integer number
                int ctr = 0;        // counter
                for (int i = 2; i <= Math.Sqrt(n); i++) // Run through numbers that might be divider of each element
                {
                    if (n % i == 0) // if there is a divider where remainder is 0, then it is not prime
                    {
                        ctr++;  // counter is true (for not prime numbers
                        break; // break checking that number, as it is not prime number
                    }
                }
                if (ctr == 0 && n != 1) // if that number is not prime, then cnr=1, otherwise cnr=0
                {
                    cnt++;        // cnt the prime numbers, where ctr is 0
                    ss += arr[j] + ' ';  // add that number (as string) to the null string
                }
            }
            Console.WriteLine(cnt); // number of primes
            Console.WriteLine(ss); // list of primes
            Console.ReadKey();
        }
    }
}
