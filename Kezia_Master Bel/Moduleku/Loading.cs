using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Component
{
    class Loading
    {
        public static void loading(int x = 20, int y = 10)
        {
            Console.CursorVisible = false;
            int play = 0;
            while (play <2 )
            {
                for (int i = 0; i <= 50; i++)
                {
                    Console.SetCursorPosition(i + x, y);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("░░░");
                    Thread.Sleep(50);
                }
                for (int i = 50; i >= 0; i--)
                {
                    Console.SetCursorPosition(i + x, y);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("░░░");
                    Thread.Sleep(50);
                }
                play++;
            }

        }

    }
}


