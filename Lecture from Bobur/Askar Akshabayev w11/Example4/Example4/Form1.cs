using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("constructor");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form load event");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //MessageBox.Show("Form paint event");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("mouse down: " + e.Location);
            //MessageBox.Show(e.Location+"");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location); 
            button1.Location = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location + "");
        }
    }
}
