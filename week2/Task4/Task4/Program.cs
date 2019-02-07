using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo from = new DirectoryInfo("../../"); //path
            DirectoryInfo to = new DirectoryInfo("../../../"); // path1
            /*
            First solution
            File.AppendAllText(from + "text.txt" , "Some text here");
            File.Copy( from + "text.txt", to + "text.txt");
            File.Delete(from + "text.txt"); 
            */
            // Second solution
            StreamWriter file = new StreamWriter(from + "text.txt");
            file.Write("Some text here goes");
            file.Close();
            File.AppendAllText(from + "text.txt", " Some addition ");
            File.Copy(from + "text.txt", to + "text.txt");
            File.Delete(from + "text.txt");
        }
    }
}