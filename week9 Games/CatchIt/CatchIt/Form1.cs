using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchIt
{
    public partial class Form1 : Form
    {
        List<Label> labels;
        public int points = 0, k = 0,r=0,g=0,b = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer2.Interval = 200;
            timer2.Enabled = true;
            labels = new List<Label>();
        }

        private void threaddd()
        {
            for (int i = 0; i < labels.Count; i++)
            {
                if ((labels[i].Location.X >= button1.Location.X) &&
                    labels[i].Location.X <= (button1.Location.X + button1.Width)/* ||
                        (labels[i].Location.X + labels[i].Width) >= button1.Location.X &&
                        (labels[i].Location.X + labels[i].Width) <= (button1.Location.X + button1.Width)*/)
                //
                {
                    if (labels[i].Location.Y == button1.Location.Y)
                    {
                        points++;
                        Random ra = new Random();
                        int r = ra.Next(0, 255);
                        int g = ra.Next(0, 255);
                        int b = ra.Next(0, 255);
                        Random random = new Random();
                        Point point = new Point();
                        point.X = random.Next(0, Width - 50);
                        point.Y = 20;
                        labels[i].Location = point;
                        button1.BackColor = Color.FromArgb(r, g, b, 16);
                    }
                    }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateLabel();
        }

        private void CreateLabel()
        {
            Label label = new Label();
            Random random = new Random();
            int x = random.Next(0,Width-50);
            int y = 20;
            Point point = new Point(x,y);
            label.Location = point;
            label.Text = k + "";k++;
            label.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold,GraphicsUnit.Point, ((byte)(204)));
            labels.Add(label);
            Controls.Add(label);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Rain();
            threaddd();
            button1.Text = points+"";
        }

        private void Rain()
        {
            for (int i = 0; i < labels.Count; i++)
            {
                Point point = labels[i].Location;
                point.Y += 10;
                if (point.Y > Height)
                {
                    Random random = new Random();
                    point.X = random.Next(0, Width - 50);
                    point.Y = 20;
                }
                labels[i].Location = point;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            string pres_btn = e.KeyCode + "";
            Point location = button1.Location;
            if (pres_btn == "A" && location.X - 10 >= 0)
            {
                location.X -= 10;
            }
            if (pres_btn == "D" && location.X + button1.Width + 10 <= Width-10)
            {
                location.X += 10;
            }
            button1.Location = location;
        }
        
    }
}
