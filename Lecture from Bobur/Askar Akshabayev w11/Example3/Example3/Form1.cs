using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        int dx = 10, dy = 10;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point location = button1.Location;
            if (location.X + button1.Width > Width || location.X < 0)
                dx *= -1;

            if (location.Y + button1.Height > Height || location.Y < 0)
                dy *= -1;

            location.X += dx;
            location.Y += dy;

            button1.Location = location;
        }
    }
}
