using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            FileInfo[] files = state.Folder.GetFiles();
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
            for (int i = list.Length; i < files.Length + list.Length; i++)
            {
                if (i == state.Index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(files[i-list.Length].Name);
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
            State state = new State { Folder = new DirectoryInfo(@"D:\"), Index = 0 };
            layers.Push(state);
           
            #region keyBoard
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

                        /*FileStream fs = new FileStream(state.Folder.GetFiles()
                            [layers.Peek().Index-layers.Peek().MaxIndex].FullName, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        Console.Clear();
                        string s = sr.ReadLine();
                        while (s != null)
                        {
                            Console.WriteLine(s);
                            s = sr.ReadLine();
                        }
                        sr.Close();

                        fs.Close();*/


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
            #endregion
        }//end Main

    }//end class
}
