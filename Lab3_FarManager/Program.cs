using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_FarManager
{
    class Program
    {
        public static void ShowFolder(State state)
        {
            Console.Clear();
            DirectoryInfo[] list = state.Folder.GetDirectories();
            for(int i = 0; i<list.Length; i++)
            {
                if(i == state.Index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write(list[i].Name);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
        

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Stack<State> layers = new Stack<State>();
            bool alive = true;
            State state = new State { Folder = new DirectoryInfo(@"C:\"), Index = 0 };
            layers.Push(state);

            while (alive)
            {
                ShowFolder(layers.Peek());
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        layers.Peek().Index--;
                        break;
                    case ConsoleKey.DownArrow:
                        layers.Peek().Index++;
                        break;
                    case ConsoleKey.Backspace:
                        layers.Pop();
                        break;
                    case ConsoleKey.Escape:
                        alive = false;
                        break;
                    case ConsoleKey.Enter:
                        DirectoryInfo f = layers.Peek().Folder.GetDirectories()[layers.Peek().Index];
                        State substate = new State
                        {
                            Folder = f,
                            Index = 0
                        };
                        layers.Push(substate);
                        break;
                    default:
                        break;
                }
            }//end while
        }//end Main
    }//end class
}
