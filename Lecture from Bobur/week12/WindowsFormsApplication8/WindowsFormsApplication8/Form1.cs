using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public List<Ball> balls;
        public Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            balls = new List<Ball>();
            Ball b1 = new Ball(g, new Point(0, 100));
            Ball b2 = new Ball(g, new Point(Width - 200, 100));

            balls.Add(b1);
            balls.Add(b2);

            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            foreach (Ball b in balls)
                b.Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in balls) { 
                b.Move(Width, Height);
                b.check(balls);
            }

            Refresh();
        }
    }
}
