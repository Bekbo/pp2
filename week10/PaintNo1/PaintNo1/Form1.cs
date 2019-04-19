using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintNo1
{
    public partial class Form1 : Form
    {
        painter painter;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            painter = new painter(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                painter.prev = e.Location;
                painter.startdraw = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (painter.startdraw)
            {
                painter.Draw(e.Location);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            painter.startdraw = false;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Pencil;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Fill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Cleaner;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Circle;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Line;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            painter.shape = Shape.Rectangle;
        }
    }
}
