using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MySnake
{
    public class Wall : Objects
    {
        public Wall(char sign) : base(0, 0, sign)
        {
            objects = new List<Point>();
        }
        public void LoadLevel(int lvlindex)
        {
            objects = new List<Point>();
            string fileName = "level" + lvlindex + ".txt";
            StreamReader sr = new StreamReader(fileName);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '*')
                        objects.Add(new Point(j, i));
        }
        public void NextLevel()
        {
            lvlindex++;
            if (lvlindex == 4)
                lvlindex = 1;
            LoadLevel(lvlindex);
        }
    }
}
