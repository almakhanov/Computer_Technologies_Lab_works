using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Worm worm = new Worm();
            Food food = new Food();
            Wall wall = new Wall(1);

            while (worm.isAlive)
            {
                Console.Clear();
                worm.Draw();
                food.Draw();
                wall.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        worm.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        worm.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        worm.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        worm.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        worm.isAlive = false;
                        break;
                }

                if (worm.CanEat(food))
                {
                    food = new Food();
                }
            }
        }
    }
}