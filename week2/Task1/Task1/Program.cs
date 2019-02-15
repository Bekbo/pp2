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
            StreamReader sr = new StreamReader("in.txt"); // Load the txt file
            string ss = sr.ReadToEnd(); // insert to a string the text of the loaded file
            bool pol = true; // boolean polindrom to show the status of text
            char[] arr = ss.ToCharArray(); // array of characters of the string
            for (int i = 0; i < arr.Length; i++) // read the array from beginning to the end
            {
                if (arr[i] != arr[arr.Length - 1 - i]) // the front char and the last character must't be the same
                    pol = false; // to state the status of boolean false
            }
            if (pol == false) // if pol = false, it's not polindrome
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES ");
            Console.ReadKey();
        }
    }
}
 