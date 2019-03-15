using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "Bekbolat";
            student.SurName = "Ospan";

            MarkS mark = new MarkS();
            mark.Subject = "PP2";
            mark.MarkSubject = 95;
            student.MarkS = mark;

            Student student2 = new Student();
            student2.Name = "Abylay";
            student2.SurName = "Ospan";

            MarkS mark2 = new MarkS();
            mark2.Subject = "Calculus";
            mark2.MarkSubject = 70;
            student2.MarkS = mark2;

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
            for (int i =0;i<studentOpen.Students.Count;i++)
            {
                Console.WriteLine(studentOpen.Students[i]);
            }
            Console.WriteLine(studentOpen);
            Console.ReadKey();
        }
    }
}
