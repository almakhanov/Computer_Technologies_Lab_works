using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab5_Snake
{
    [Serializable]
    public class Worm : Drawer
    {
        public Worm() { }

        public Worm(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body) { }

        public void Move(int dx, int dy)
        {
            //Delete();
            
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
                Delete();
            }

            body[0].x += dx;
            body[0].y += dy;

            Border();
            CollisionWall();
            CollisionSnake();
            NewFood();
            NewLevel();
           
        }



        public void CollisionWall()
        {
            for (int i = 0; i < Game.wall.body.Count; i++)
            {

                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over");
                    Console.ReadKey();
                    Game.GameOver = true;
                }
            }
        }

        public void CollisionSnake()
        {
            for (int i = 2; i < Game.snake.body.Count; i++)
            {

                if (Game.snake.body[0].x == Game.snake.body[i].x && Game.snake.body[0].y == Game.snake.body[i].y)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over");
                    Console.ReadKey();
                    Game.GameOver = true;

                }
            }
        }

        public void NewFood()
        {
            if (Game.snake.CanEat(Game.food))
            {
                Game.food.SetRandomPosition();
            }
        }

        public void NewLevel()
        {

            if (Game.snake.body.Count == 4)
            {
                Game.wall.LoadLevel(2);
            }

            if (Game.snake.body.Count == 8)
            {
                Game.wall.LoadLevel(3);
            }
        }

        public void Border()
        {
            if (body[0].x == 70) body[0].x = 1;
            if (body[0].y == 35) body[0].y = 1;
            if (body[0].x <= 0) body[0].x = 70;
            if (body[0].y <= 0) body[0].y = 35;
        }

        public bool CanEat(Food f)
        {
            if (body[0].x == f.body[0].x && body[0].y == f.body[0].y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            return false;
        }

        public void Delete()
        {
            if (body[body.Count - 1].x == body[body.Count - 2].x && body[body.Count - 1].y == body[body.Count - 2].y)
            {
                Console.Clear();
                Console.Write(' ');
            }
        }

    }
}