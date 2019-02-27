using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Week5._1
{
    public class Library
    {
        public string BookName;
        public string BookAuthor;
        public string BookOwnerName;
        public Library() { }
        public Library(string BookName, string BookAuthor, string BookOwnerName)
        {
            this.BookName = BookName;
            this.BookAuthor = BookAuthor;
            this.BookOwnerName = BookOwnerName;
        }
    }
    public class Student
    {
        public string Name;
        public string Surname;
        public int Year;
        public string StudentBook;
        public string FinalDate;
        public List<Student> Studlist;
        public Student() { }
        public Student(string Name, string Surname, int Year, string StudentBook, string FinalDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Year = Year;
            this.StudentBook = StudentBook;
            this.FinalDate = FinalDate;
            Studlist = new List<Student>();
        }
    }
    class Program
    {
        public static void WriteInFile(List<Student> list)
        {
	    Student student = new Student();
            FileStream fs = new FileStream("owners.xml", FileMode.Truncate, FileAccess.ReadWrite);
            foreach (var v in list)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                xs.Serialize(fs, v);
            }
            fs.Close();
        }
        public static void F(List<Student> list)
        {
            FileStream fs = new FileStream("owners.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            foreach (var v in list)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Student));
                Student student = xs.Deserialize(fs) as Student;
            }
            fs.Close();
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("student.txt");
            string next = null;
            List<Student> list = new List<Student>();
            do
            {
                Student student = new Student();
                student.Name = sr.ReadLine();
                student.Surname = sr.ReadLine();
                student.Year = int.Parse(sr.ReadLine());
                student.StudentBook = sr.ReadLine();
                student.FinalDate = sr.ReadLine();
                list.Add(student);
                next = sr.ReadLine();
            } while (next != null);
            WriteInFile(list);
            //F(list);
        }
    }
}
