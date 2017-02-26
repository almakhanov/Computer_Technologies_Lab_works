using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace NMySnake.Model
{
    [Serializable]
    public class Snake : Drawer
    {
        public Snake() { }
        public Snake(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body) { }

        public void Move(int dx, int dy)
        {
            delete();

            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            Border();
            CollesionWall();
            CollesionSnake();
            NewFood();
            NewLevel();
            // TODO: can snake eat?
            // TODO: check for collision with wall 
            // TODO: check for collision with itself (snake)
            // TODO: check for collision with border (console border (maximum width and height))
            // TODO: if necessary, load new level of the wall
        }

        public void CollesionWall()
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
        public void CollesionSnake()
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

        public void delete()
        {
            if (body[body.Count - 1].x == body[body.Count - 2].x && body[body.Count - 1].y == body[body.Count - 2].y)
            {
                Console.Clear();
                Console.Write(' '); 

            }



        }
        /*
        public void save()
        {
            FileStream fs = new FileStream("snake.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();            
        }

        public void deser()
        {
            FileStream fs = new FileStream("snake.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Snake snake = bf.Deserialize(fs) as Snake;
            this.body = snake.body;
            this.color = snake.color;
            this.sign = snake.sign;


            fs.Close();
        }
        */
    }
}