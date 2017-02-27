using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace Lab5_Snake
{
    class Menu : Drawer
    {
        public static string[] s = { "New Game", "Continue Game", "Exit" };
        
        public static int index = 0;
        public static bool a = true;

        public static void MenuBar()
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
                        if(index > 0)
                        index--;
                        MenuBar();
                        break;
                    case ConsoleKey.DownArrow:
                        if(index < 2)
                        index++;
                        MenuBar();
                        break;
                    case ConsoleKey.Enter:
                        if(index == 0)
                        {
                            Game.Init();
                            Game.Move();
                        }
                        if(index == 1)
                        {
                            //Game.Init();
                            Console.Clear();
                            Console.SetWindowSize(100, 35);
                            Console.CursorVisible = false;
                            Console.SetWindowPosition(0, 0);
                            Thread t2 = new Thread(new ThreadStart(Game.Move));
                            

                            List<Point> wall_body = new List<Point>();
                            Game.wall = new Wall(ConsoleColor.Red, '#', wall_body);

                            List<Point> snake_body = new List<Point>();
                            snake_body.Add(new Point(10, 10));
                            snake_body.Add(new Point(9, 10));
                            Game.snake = new Worm(ConsoleColor.Yellow, 'o', snake_body);

                            List<Point> food_body = new List<Point>();
                            food_body.Add(new Point(0, 0));
                            Game.food = new Food(ConsoleColor.Green, '@', food_body);

                            Game.snake.Continue();
                            Game.wall.Continue();
                            Game.food.Continue();
                            Game.GameOver = false;
                            
                            Game.Move();
                            t2.Start();
                            while (true)
                            {
                                Game.snake.Move(Game.Qx, Game.Qy);
                                Game.Draw();
                                Thread.Sleep(400);
                            }
                            //Game.Move();




                            //Game.Draw();


                        }
                        if(index == 2)
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
