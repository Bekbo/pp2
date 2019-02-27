using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_1
{
    class FarManager
    {
        public int cursor = 0; // position of the cursor
        public int size;
        public int top = 0;
        public int down;
        public int sh = 10;
        FileSystemInfo curfs = null; // the current FileSystemInfo where the cursor is

        public FarManager()
        {
            cursor = 0;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor) // if the index of FileSystemInfo == cursor position
            {
                Console.BackgroundColor = ConsoleColor.Red; // these colors appear
                Console.ForegroundColor = ConsoleColor.White;
                curfs = fs; // current fileSystemInfo is where the index == cursor
            }
            else if (fs.GetType() == typeof(DirectoryInfo)) // else if the FileSystemInfo where the cursor is folder
            {
                Console.BackgroundColor = ConsoleColor.Black;// these colors appear
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; // or these, if it is file
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path); // main directory is path
            FileSystemInfo[] fileSystemInfos = new FileSystemInfo[directory.GetFileSystemInfos().Length]; // array consists of each element in the directory
            int ii = 0; 
            // Add folders first, then files
            foreach (FileSystemInfo fadd in directory.GetFileSystemInfos()) // foreach FileSystemInfo in directory do
            {
                if (fadd.GetType() == typeof(DirectoryInfo)) // if fadd is a folder
                {
                    fileSystemInfos[ii] = fadd; // add to the array
                    ii++;
                }
            }
            foreach (FileSystemInfo fadd in directory.GetFileSystemInfos())
            {
                if (fadd.GetType() != typeof(DirectoryInfo)) // id fadd is not folder add to the array
                {
                    fileSystemInfos[ii] = fadd;
                    ii++;
                }
            }
            int index = 0, size = fileSystemInfos.Length; // index starts from zero
            for (int i = top; i < sh; i++)
            {
                FileSystemInfo fs = fileSystemInfos[i];
                int filen = 0, folder = 0;
                if (fs.GetType() == typeof(DirectoryInfo))
                {
                    DirectoryInfo papka = new DirectoryInfo(fs.FullName);
                    folder = papka.GetDirectories().Length;
                    filen = papka.GetFiles().Length;
                }
                Color(fs, i); // give colors to each fs
                Console.WriteLine(i + 1 + ". " + fs.Name + " " + folder + " " + filen); // Write in Console the name of fs
                index++; // increment index as it goes down in console
            }
        }

        public void Start(string path)
        {
            Show(path);
            DirectoryInfo directory = new DirectoryInfo(path); // main directory is path
            FileSystemInfo[] fileSystemInfos = new FileSystemInfo[directory.GetFileSystemInfos().Length];
            // array of FileSystemInfo with size equal number of directories
            int ii = 0; // index of elements in the array
            // Add folders first, then files
            foreach (FileSystemInfo fadd in directory.GetFileSystemInfos()) // foreach FileSystemInfo in directory do
            {
                if (fadd.GetType() == typeof(DirectoryInfo)) // if fadd is a folder
                {
                    fileSystemInfos[ii] = fadd; // add to the array
                    ii++;
                }
            }
            foreach (FileSystemInfo fadd in directory.GetFileSystemInfos())
            {
                if (fadd.GetType() != typeof(DirectoryInfo)) // id fadd is not folder add to the array
                {
                    fileSystemInfos[ii] = fadd;
                    ii++;
                }
            }
            ConsoleKeyInfo cnskey = Console.ReadKey(); // key from the keyboard
            while (cnskey.Key != ConsoleKey.X)  // while the keyboard is not in X
            {
                size = directory.GetFileSystemInfos().Length;
                Console.BackgroundColor = ConsoleColor.Black; // background color
                Console.Clear(); // clear the console from texts in each time for new cnskey
                Show(path); // out the list of files
                cnskey = Console.ReadKey(); // read the key
                if (cnskey.Key == ConsoleKey.Escape) // if Esc
                {
                    cursor = 0;
                    directory = directory.Parent; // go one folder upper
                    path = directory.FullName; // change path to new, upper folder
                }
                if (cnskey.Key == ConsoleKey.UpArrow)// if UpArrow
                {
                    cursor--; // decrement the cursor as it goes down
                    if (cursor < 0)
                    {
                        cursor = size - 1; // if cursor goes outside of 0, set it to the bottom
                        sh = size;
                        top = size - 10;
                    }
                    if (cursor < top)
                    {
                        top--;
                        sh--;
                    }
                }
                if (cnskey.Key == ConsoleKey.DownArrow)
                {
                    cursor++; // increment the cursor position as it goes upper
                    if (cursor == size)
                    {
                        cursor = 0; //if cursor goes outside of the size of array, set it to the start position
                        top = 0;
                        sh = 10;
                    }
                    if (cursor > sh-1)
                    {
                        top++;
                        sh++;
                    }
                }
                if (cnskey.Key == ConsoleKey.F2) // change the name for F2
                {
                    string ext = Path.GetExtension(curfs.FullName); // ext gets the file extension of given path
                    Console.BackgroundColor = ConsoleColor.Black; // refresh the screen
                    Console.Clear(); // refresh
                    Console.WriteLine("New name for {0} :", curfs.Name); // write to enter new name
                    string name = Console.ReadLine(); // read new name
                    if (curfs.GetType() == typeof(DirectoryInfo)) // if user changes folder name
                    {
                        Directory.Move(curfs.FullName, Path.GetDirectoryName(curfs.FullName) + "/" + name);
                        // Move the file from the the position of the folder to new folder in the same position but with new
                        // name
                    }
                    else
                    {
                        File.Copy(curfs.FullName, Path.GetDirectoryName(curfs.FullName) + "/" + name + ext);
                        // copy from initial position and put in same position with new name
                        File.Delete(curfs.FullName); // delete initial file
                    }
                    cursor = 0;// refresh the cursor
                }
                if (cnskey.Key == ConsoleKey.Delete) // if Del
                {
                    if (curfs.GetType() == typeof(DirectoryInfo)) // if its folder
                        Directory.Delete(curfs.FullName, true); // delete the folder with its all elements on it
                    else
                        File.Delete(curfs.FullName); // or delete a file
                    cursor = 0;
                }
                if (cnskey.Key == ConsoleKey.Enter) // Enter
                {
                    if (curfs.GetType() == typeof(DirectoryInfo)) // if Folder
                    {
                        cursor = 0; // refresh cursor position
                        directory = new DirectoryInfo(curfs.FullName); // redirect
                        path = curfs.FullName; // re path
                    }
                    else // if file
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear(); // refresh the screen
                        using (StreamReader reader = File.OpenText(curfs.FullName)) // read the txt file
                        {
                            string line = null; // each line in one string
                            do
                            {
                                line = reader.ReadLine(); // each line is one line of the file
                                Console.WriteLine(line); // output that line
                            } while (line != null); // while it is not null
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarManager farmanager = new FarManager(); //new class FarManager
            farmanager.Start("C:/Users/User/Desktop/");// set initial path
        }
    }
}