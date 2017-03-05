using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeII
{
    public class Game : IDrawable
    {
        public static int WIDTH;
        public static int HEIGTH;
        public static int SPEED;
        public static int LEVEL;

        public Game()
        {
            Game.WIDTH = 100;
            Game.HEIGTH = 35;
            Game.SPEED = 300;
            LEVEL = 1;
            Console.SetWindowSize(Game.WIDTH, Game.HEIGTH);
            Console.SetBufferSize(Game.WIDTH + 20, Game.HEIGTH + 20);
            Console.CursorVisible = false;
        }
        bool isalive;
        Worm worm = null;
        Wall wall = null;
        Food food = null;
        Thread t = null;

        public void Draw()
        {
            worm.Draw();
            wall.Draw();
            food.Draw();
        }

        public void Save()
        {
            worm.Save();
            wall.Save();
            food.Save();
        }

        public void Load()
        {
            worm = new Worm();
            worm.LinkToGame(this);

            wall = new Wall();
            food = new Food();
            food.Generate();
            //food.SetRandomPosition();
            worm.Generate();

            wall.Generate(LEVEL);
        }

        public bool CanEat()
        {
            if (worm.points[0].Equals(food.points[0]))
            {
                worm.points.Add(food.points[0]);
                food.SetRandomPosition();
                food.Draw();
                worm.score++;
                return true;
            }

            return false;
        }

        
        public bool WC() {
            for (int i = 0; i < worm.points.Count; i++) {
                for (int j = 0; j < wall.points.Count; j++) {
                    if (worm.points[i].Equals(wall.points[j])) {
                        return true;
                    }
                }
            }
            for (int i = 2; i < worm.points.Count; i++)
            {
                if (worm.points[1].Equals(worm.points[i]))
                {
                    
                    return true;
                }
            }
            //isalive = false;
            return false;
        }

        public void Start(bool is_new_game)
        {
            if (is_new_game)
            {
                Load();
            }
            else
            {
                worm = new Worm();
                worm = worm.Load() as Worm;
                worm.LinkToGame(this);

                food = new Food();

                food = food.Load() as Food;
                wall = new Wall();
                wall = wall.Load() as Wall;

            }


            worm.Draw();
            wall.Draw();
            food.Draw();

            t = new Thread(new ThreadStart(worm.Move));

            t.IsBackground = true;
            t.Start();

            isalive = true;
            while (isalive)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.F3:
                        wall = wall.Load() as Wall;
                        worm = worm.Load() as Worm;
                        worm.LinkToGame(this);
                        t.Abort();

                        t = new Thread(new ThreadStart(worm.Move));
                        t.IsBackground = true;
                        Console.Clear();
                        worm.Draw();
                        wall.Draw();
                        food.Draw();
                        t.Start();

                        break;
                    case ConsoleKey.F2:
                        this.Save();
                        break;
                    case ConsoleKey.UpArrow:
                        worm.dx = 0;
                        worm.dy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        worm.dx = 0;
                        worm.dy = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        worm.dx = -1;
                        worm.dy = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        worm.dx = 1;
                        worm.dy = 0;
                        break;
                    case ConsoleKey.Escape:
                        isalive = false;
                        Console.Clear();
                        Menu m = new Menu();

                        m.MenuBar();
                        break;
                }
            }
        }

    }
}