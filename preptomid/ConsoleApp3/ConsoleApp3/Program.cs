using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace ConsoleApp3
{
    enum State
    {
        RED,
        GREEN,
        YELLOW
    };

    class Traffic
    {
        State state;

        public Traffic()
        {
            state = State.RED;
        }

        public void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                switch (state)
                {
                    case State.RED:
                        if (i == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        break;
                    case State.YELLOW:
                        if (i == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        break;
                    case State.GREEN:
                        if (i == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        break;
                }
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 14; k++)
                    {
                        Console.SetCursorPosition(10 + k, 10 + 10 * i + j);
                        Console.Write("█");
                    }
                }
            }
        }

        public void Update()
        {
            switch (state)
            {
                case State.RED:
                    state = State.YELLOW;
                    break;
                case State.YELLOW:
                    state = State.GREEN;
                    break;
                case State.GREEN:
                    state = State.RED;
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Traffic traffic = new Traffic();
            traffic.Draw();
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += (obj, arg) =>
            {
                traffic.Update();
                traffic.Draw();
            };
            timer.Enabled = true;
            Thread.CurrentThread.Join();
        }
    }
}