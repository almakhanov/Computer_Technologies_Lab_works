using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NMySnake.Model
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
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 35);
            
            // TODO: is x and y on the wall?
            // TODO: is x and y on the snake?
            body[0] = new Point(x, y);
           // CollesionWalls();
            //CollesionSnakes();

            
        }

        
        public void CollesionWalls()
        {


           /* while(Game.snake.body.Contains(p) || Game.wall.body.Contains(p))
            {
                p = new Point

            }*/

            for (int i = 0; i < Game.wall.body.Count; i++)
            {

                if (Game.food.body[0].x == Game.wall.body[i].x && Game.food.body[0].y == Game.wall.body[i].y)
                {
                    SetRandomPosition();
                }
            }
            
        }


        public void CollesionSnakes()
        {
            for (int i = 0; i < Game.snake.body.Count; i++)
            {

                if (Game.food.body[0].x == Game.snake.body[i].x && Game.food.body[0].y == Game.snake.body[i].y)
                {

                    SetRandomPosition();
                }
            }
        }
        /*
        public void save()
        {
            FileStream fs = new FileStream("food.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void deser()
        {
            FileStream fs = new FileStream("food.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Food food = bf.Deserialize(fs) as Food;
            this.body = food.body;
            this.color = food.color;
            this.sign = food.sign;


            fs.Close();
        }
        */
    }
}