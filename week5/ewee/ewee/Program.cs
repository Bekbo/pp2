using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ewee
{
    public class StudList
    {
        public List<Students> Students;

        public StudList()
        {
            Students = new List<Students>();
        }
    }
    public class Students
    {
        public string Name;
        public List<MarkS> MarkS;

        public Students() { }
        public Students(string Name, List<MarkS> MarkS)
        {
            this.Name = Name;
            MarkS = new List<MarkS>();
        }

        public override string ToString()
        {
            return Name +" "+ MarkS;
        }

    }
    public class MarkS
    {
        public string Subject;
        public int MarkSubject;
        public MarkS() { }
        public MarkS(string Subject, int MarkSubject)
        {
            this.Subject = Subject;
            this.MarkSubject = MarkSubject;
        }
        public string GetLetter()
        {
            if (MarkSubject > 94)
                return Subject + " A";
            if (MarkSubject > 89)
                return Subject + " A-";
            if (MarkSubject > 84)
                return Subject + " B+";
            if (MarkSubject > 79)
                return Subject + " B";
            if (MarkSubject > 74)
                return Subject + " B-";
            if (MarkSubject > 69)
                return Subject + " C+";
            if (MarkSubject > 64)
                return Subject + " C";
            if (MarkSubject > 59)
                return Subject + " C-";
            if (MarkSubject > 54)
                return Subject + " D+";
            if (MarkSubject > 49)
                return Subject + " D";
            return Subject + " F";
        }
        public override string ToString()
        {
            return GetLetter();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students student = new Students();
            student.Name = "Bekbolat";

            MarkS marks = new MarkS();
            marks.Subject = "PP2";
            marks.MarkSubject = 95;
            student.MarkS.Add(marks);

            MarkS marks2 = new MarkS();
            marks2.Subject = "Calculus";
            marks2.MarkSubject = 77;
            student.MarkS.Add(marks2);

            Students student2 = new Students();
            student.Name = "Bekbolat";

            MarkS marks3 = new MarkS();
            marks3.Subject = "PP1";
            marks3.MarkSubject = 100;
            student.MarkS.Add(marks3);

            StudList studList = new StudList();
            studList.Students.Add(student);
            studList.Students.Add(student2);

            FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(StudList));
            xs.Serialize(fs, studList);
            fs.Close();

            FileStream fsopen = new FileStream("students.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xsopen = new XmlSerializer(typeof(StudList));
            StudList studentOpen = xsopen.Deserialize(fsopen) as StudList;
            for (int i = 0; i < studentOpen.Students.Count; i++)
            {
                Console.WriteLine(studentOpen.Students[i]);
            }
            Console.WriteLine(studentOpen);
            Console.ReadKey();
        }
    }
}
