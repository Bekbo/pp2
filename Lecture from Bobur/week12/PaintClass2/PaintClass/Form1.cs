using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintClass
{
    public partial class Form1 : Form
    {
        private PaintBase paint;
        public Form1()
        {
            InitializeComponent();
            paint = new PaintBase(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint.prev = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                paint.Draw(e.Location);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.shape = Shape.Pencil;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint.SaveLastPath();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            // load selected picture to Bitmap in PaintBase class
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG file|*.jpg|PNG files|*.png";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                paint.SaveImage(saveFileDialog1.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                paint.pen.Color = colorDialog1.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint.ClearBtm();
        }
    }
}
