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
            DirectoryInfo from = new DirectoryInfo(@"C:\Users\User\Desktop\Univer\pp2\week2\Task4"); //path
            DirectoryInfo to = new DirectoryInfo(@"C:\Users\User\Desktop\Univer\pp2\week2\Task4\Task4\"); // path1
            StreamWriter file = new StreamWriter(from + "text.txt"); // create a file, or load it, if exists
            file.Write("Some text here goes"); // write on the file
            file.Close(); // close writing
            File.AppendAllText(from + "text.txt", " Some addition "); //add some texts again
            File.Copy(from + "text.txt", to + "newtext.txt"); // copy the file from initial path, to a folder upper
            File.Delete(from + "text.txt");// delete the initial file
        }
    }
}