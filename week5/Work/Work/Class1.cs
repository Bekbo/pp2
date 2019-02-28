using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    public class Student
    {
        public string Name;
        public string SurName;
        public MarkS MarkS;

        public Student() { }
        public Student(string Name,string SurName,MarkS MarkS)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.MarkS = MarkS;
        }
        public override string ToString()
        {
            return Name + " " + SurName + " " + MarkS;
        }
    }
    public class MarkS
    {
        public string Subject;
        public int MarkSubject;
        public MarkS() { }
        public MarkS(string Subject,int MarkSubject)
        {
            this.Subject = Subject;
            this.MarkSubject = MarkSubject;
        }
        public string GetLetter()
        {
            if (MarkSubject > 94)
                return Subject + " A";
            if (MarkSubject > 89)
                return Subject + "A-";
            if (MarkSubject > 84)
                return Subject + "B+";
            if (MarkSubject > 79)
                return Subject + "B";
            if (MarkSubject > 74)
                return Subject + "B-";
            if (MarkSubject > 69)
                return Subject + "C+";
            if (MarkSubject> 64)
                return Subject + "C";
            if (MarkSubject > 59)
                return Subject + "C-";
            if (MarkSubject > 54)
                return Subject + "D+";
            if (MarkSubject > 49)
                return Subject + "D";
            return Subject + "F";
        }
        public override string ToString()
        {
            return GetLetter();
        }
    }
    public class StudList
    {
        public List<Student> Students;

        public StudList()
        {
            Students = new List<Student>();
        }
        public override string ToString()
        {
            return Students + "";
        }
    }
}
