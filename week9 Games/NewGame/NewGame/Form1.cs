using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGame
{
    public partial class Form1 : Form
    {
        List<particles> labels;
        public int aa = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer2.Interval = 100;
            timer1.Enabled = true;
            timer2.Enabled = true;
            labels = new List<particles>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateLabel();
            if (labels.Count > 10)
                timer1.Stop();
        }

        private void CreateLabel()
        {
            particles p = new particles();
            Label label = new Label();
            string[] dirs = {"RU","RD", "LU", "LD" };
            string dir;
            Random random = new Random();
            int k = random.Next(0, 3);
            dir = dirs[k];
            int x = random.Next(0, Width - 50);
            int y = random.Next(0,Height-50);
            Point point = new Point(x, y);
            label.Location = point;
            label.Text = aa + "";
            aa++;
            label.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label.Width = 13; label.Height = 15;
            label.BackColor = Color.Black; label.ForeColor = Color.White;
            p.label = label;
            p.dir = dir;
            labels.Add(p);
            Controls.Add(label);
        }

        private void Rain()
        {
            for (int i = 0; i < labels.Count; i++)
            {
                Point point = labels[i].label.Location;
                if (labels[i].dir == "RU")
                {
                    point.X += 10;
                    point.Y -= 10;
                }
                if (labels[i].dir == "RD")
                {
                    point.X += 10;
                    point.Y += 10;
                }
                if (labels[i].dir == "LU")
                {
                    point.X -= 10;
                    point.Y -= 10;
                }
                if (labels[i].dir == "LD")
                {
                    point.X -= 10;
                    point.Y += 10;
                }
                if (point.X<=100 || point.Y<=100 || point.X>=Width-40 || point.Y>=Height-70)
                {
                    Changedir(labels[i]);
                }
                labels[i].label.Location = point;
            }
        }
        
        private particles Changedir(particles p)
        {
            if (p.label.Location.X <= 10)
            {
                if (p.dir == "LU")
                {
                    p.dir = "RU";
                }
                if (p.dir == "LD")
                {
                    p.dir = "RD";
                }
            }
            if (p.label.Location.X >= Width-40)
            {
                if (p.dir == "RU")
                {
                    p.dir = "LU";
                }
                if (p.dir == "RD")
                {
                    p.dir = "LD";
                }
            }
            if (p.label.Location.Y <= 10)
            {
                if (p.dir == "RU")
                {
                    p.dir = "RD";
                }
                if (p.dir == "LU")
                {
                    p.dir = "LD";
                }
            }
            if (p.label.Location.Y >= Height-70)
            {
                if (p.dir == "LD")
                {
                    p.dir = "LU";
                }
                if (p.dir == "RD")
                {
                    p.dir = "RU";
                }
            }
            return p;
        }


        private void IsCollWithObject(Label label,int k,string dir)
        {
            string temp = dir;
            for (int i = 0; i < labels.Count; i++)
            {
                if (i!=k){
                    if (label.Location.X >= labels[i].label.Location.X &&
                        label.Location.X <= labels[i].label.Location.X + label.Width && 
                        label.Location.Y >= labels[i].label.Location.Y &&
                        label.Location.Y <= labels[i].label.Location.Y + label.Height)
                    {
                        labels[k].dir = labels[i].dir;
                        labels[i].dir = temp;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Rain();
            for (int i = 0; i < labels.Count; i++)
            {
                IsCollWithObject(labels[i].label, i, labels[i].dir);
            }
        }
    }
}
