using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSnake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //Console.SetWindowSize(80, 30);
            //Console.SetBufferSize(80, 30);
            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}
