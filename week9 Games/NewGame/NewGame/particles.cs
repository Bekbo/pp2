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

namespace NewGame
{
    public class particles
    {
        public Label label;
        public string dir;
        public particles() { }
        public particles(Label label, string dir)
        {
            this.label = label;
            this.dir = dir;
        }
    }
}
