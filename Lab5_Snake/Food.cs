using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Snake
{
    [Serializable]
    public class Food : Drawer
    {
        public Food() { }
        
        public Food(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 34);

            body[0] = new Point(x, y);
        }

        public void CollisionWalls()
        {
            for(int i = 0; i < Game.wall.body.Count; i++)
            {
                if(Game.food.body[0].x == Game.wall.body[i].x && Game.food.body[0].y == Game.wall.body[i].y)
                {
                    SetRandomPosition();
                }
            }
        }

        public void CollisionSnake()
        {
            for(int i = 0; i < Game.snake.body.Count; i++)
            {
                if (Game.food.body[0].x == Game.snake.body[i].x && Game.food.body[0].y == Game.snake.body[i].y)
                {
                    SetRandomPosition();
                }
            }
        }
        
    }
}