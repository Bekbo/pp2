using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    public class MarkList
    {
        public List<Mark> Marks;

        public MarkList()
        {
            Marks = new List<Mark>();
        }

        public void Ser(MarkList markList)
        {
            FileStream fs = new FileStream("markslists.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(MarkList));
            xs.Serialize(fs, markList);
            fs.Close();
        }

        public void Des()
        {
            FileStream fs = new FileStream("markslists.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(MarkList));
            MarkList markList = xs.Deserialize(fs) as MarkList;
            for (int i = 0; i < markList.Marks.Count; i++)
            {
                Console.WriteLine(markList.Marks[i]);
            }
            Console.ReadKey();
        }
    }
    public class Mark
    {
        public int point;

        public Mark() { }
        public Mark(int point)
        {
            this.point = point;
        }

        public string GetLetter()
        {
            if (point > 94)
                return "A";
            if (point > 89 && point <95)
                return "A-";
            if (point > 84 && point < 90)
                return "B+";
            if (point > 79 && point < 85)
                return "B";
            if (point > 74 && point < 80)
                return "B-";
            if (point > 69 && point < 75)
                return "C+";
            if (point > 64 && point < 70)
                return "C";
            if (point > 59 && point < 65)
                return "C-";
            if (point > 54 && point < 60)
                return "D+";
            if (point > 49 && point < 55)
                return "D";
            return "F";
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
            Mark m1 = new Mark(97);
            Mark m2 = new Mark(43);
            Mark m3 = new Mark(75);
            MarkList markList = new MarkList();
            markList.Marks.Add(m1);
            markList.Marks.Add(m2);
            markList.Marks.Add(m3);
            markList.Ser(markList);
            markList.Des();
        }
    }
}
