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
            Thread t = new Thread((Move));
            
            Console.SetWindowSize(70, 35);
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);

            GameOver = false;

            List<Point> wall_body = new List<Point>();
            wall = new Wall(ConsoleColor.Blue, '#', wall_body);

            List<Point> snake_body = new List<Point>();
            snake_body.Add(new Point(10, 10));
            snake_body.Add(new Point(9, 10));
            snake = new Worm(ConsoleColor.Magenta, 'o', snake_body);

            List<Point> food_body = new List<Point>();
            food_body.Add(new Point(0, 0));
            food = new Food(ConsoleColor.Green, '@', food_body);

            t.Start();

            while (true)
            {
                snake.Move(Qx, Qy);
                Draw();
                Thread.Sleep(300);
                
            }
            
        }

        public static void Move()
        {
            
                        
            while (!Game.GameOver)
            {
                Game.Draw();              

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
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.F2:
                        snake.Save();
                        wall.Save();
                        food.Save();
                        break;
                    case ConsoleKey.F3:
                        //snake.release();
                        //wall.release();
                        //food.release();
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
        }

    }
}
