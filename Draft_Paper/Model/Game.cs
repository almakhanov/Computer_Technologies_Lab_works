using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMySnake.Model
{
    [Serializable]
    public class Game 
    {
        public static bool GameOver;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public Game() { }

        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 35);

            GameOver = false;

            // wall init
            List<Point> wall_body = new List<Point>();
            wall = new Wall(ConsoleColor.Red, '#', wall_body);


            // snake init

                      
                List<Point> snake_body = new List<Point>();
                snake_body.Add(new Point(10, 10));
                snake_body.Add(new Point(9, 10));
                snake = new Snake( ConsoleColor.Yellow, 'o', snake_body);
            
            // food init
            List<Point> food_body = new List<Point>();
            food_body.Add(new Point(0, 0));
            food = new Food(ConsoleColor.Green, '$', food_body);

          
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
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.F2:
                        snake.save();
                        wall.save();
                        food.save();
                        break;
                    case ConsoleKey.F3:
                        snake.release();
                        wall.release();
                        food.release();
;                        break;

                }
            }

        }

        public static void Draw()
        {
            //Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }

        // TODO: The Save function for all classes like Draw() above
        // TODO: The Resume function for all classes like Draw() above



    }
}