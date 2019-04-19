using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            string pressed_btn = e.KeyCode + "";
            Point location = button1.Location;
            if (pressed_btn == "A")
                location.X -= 10;
            else if (pressed_btn == "D")
                location.X += 10;

            button1.Location = location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point location = label1.Location;
            location.Y += 10;
            label1.Location = location;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
