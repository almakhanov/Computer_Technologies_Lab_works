using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab5_Snake
{
    [Serializable]
    public class Game
    {
        public static bool GameOver;
        public static Worm snake;
        public static Food food;
        public static Wall wall;
        public static int Qx = 0;
        public static int Qy = 0;

        public Game() { }

        public static void Init()
        {
            Thread t = new Thread(new ThreadStart(Game.Move));
           // Thread t2 = new Thread(new ThreadStart(Move(Qx, Qy)));
            
            Console.SetWindowSize(100, 35);
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            

            GameOver = false;

            List<Point> wall_body = new List<Point>();
            wall = new Wall(ConsoleColor.Red, '#', wall_body);

            List<Point> snake_body = new List<Point>();
            snake_body.Add(new Point(10, 10));
            snake_body.Add(new Point(9, 10));
            snake = new Worm(ConsoleColor.Yellow, 'o', snake_body);

            List<Point> food_body = new List<Point>();
            food_body.Add(new Point(0, 0));
            food = new Food(ConsoleColor.Green, '@', food_body);

            t.Start();

            while (true)
            {
                snake.Move(Qx, Qy);
                Draw();
                Thread.Sleep(400);                
            }
            
        }

        public static void Move()
        {
            
                        
            while (!GameOver)
            {
                Draw();              

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        Qx = 0;
                        Qy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        Qx = 0;
                        Qy = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        Qx = -1;
                        Qy = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        Qx = 1;
                        Qy = 0;
                        break;
                    case ConsoleKey.Escape:
                        GameOver = true;
                        Console.Clear();

                        break;
                    case ConsoleKey.F2:
                        snake.Save();
                        wall.Save();
                        food.Save();
                        break;
                    case ConsoleKey.F3:
                        snake.Continue();
                        wall.Continue();
                        food.Continue();
                        break;
                }
                //Thread.Sleep(1000);

                

            }
        }

        
        public static void Draw()
        {            
            snake.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(71,1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("| F2 - Save");
            Console.SetCursorPosition(71, 2);
            Console.WriteLine("| Esc - Exit");
            Console.SetCursorPosition(71, 3);
            Console.WriteLine("| F3 - Release");
            Console.SetCursorPosition(71, 4);
            Console.WriteLine("| UpArrow - Move Up");
            Console.SetCursorPosition(71, 5);
            Console.WriteLine("| DownArrow - Move Down");
            Console.SetCursorPosition(71, 6);
            Console.WriteLine("| LeftArrow - Move Left");
            Console.SetCursorPosition(71, 7);
            Console.WriteLine("| RightArrow - Move Right");
            Console.SetCursorPosition(71, 8);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 9);
            Console.WriteLine("| Score - "+ snake.body.Count);
            Console.SetCursorPosition(71, 10);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 11);
            Console.WriteLine("| Level - {0}", snake.body.Count/4+1);
            Console.SetCursorPosition(71, 12);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 13);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 14);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 15);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 16);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 17);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 18);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 19);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 20);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 21);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 22);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 23);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 24);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 25);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 26);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 27);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 28);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 29);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 30);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 31);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 32);
            Console.WriteLine("|");
            Console.SetCursorPosition(71, 33);
            Console.WriteLine("|");
            

        }

    }
}
