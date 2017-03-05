using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Menu : Game
    {
        public string[] s = { "New Game", "Continue Game", "Exit" };

        public int index = 0;
        public bool a = true;



        public void MenuBar()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {

                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(s[i]);
            }

            while (a)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        MenuBar();
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < 2)
                            index++;
                        MenuBar();
                        break;
                    case ConsoleKey.Enter:
                        if (index == 0)
                        {
                            Console.Clear();
                            Game g = new Game();
                            g.Start(true);


                        }
                        if (index == 1)
                        {
                            Console.Clear();
                            Game g = new Game();
                            g.Start(false);

                        }
                        if (index == 2)
                        {
                            a = false;
                        }
                        break;
                    default:
                        break;
                }
            }//end while

        }
    }
}