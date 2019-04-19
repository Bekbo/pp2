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
        Image image;
        Bitmap btm;
        public Form1()
        {
            InitializeComponent();
            image = Image.FromFile(@"1.jpg");
            btm = new Bitmap(@"1.jpg");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(image, 0, 0);
            e.Graphics.DrawImage(btm, 0, 0, 300, 300);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location.ToString());
            //Console.WriteLine(e.Location);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location);
        }
    }
}
