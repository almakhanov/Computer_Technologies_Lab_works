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
    public class Drawer
    {
        public ConsoleColor color;
        public List<Point> body = new List<Point>();
        public char sign;

        public Drawer() { }

        public Drawer(ConsoleColor color, char sign, List<Point> body)
        {
            this.body = body;
            this.color = color;
            this.sign = sign;
        }

        public void Draw()
        {
            int i = 1;

            Console.ForegroundColor = color;
            foreach (Point p in body)
            {


                //Console.ForegroundColor = (i == 1) ? ConsoleColor.Red : color;

                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                i++;
            }
        }


        public void save()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format("{0}.dat", t.Name), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void release()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format("{0}.dat", t.Name), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            if (t == typeof(Wall))
                Game.wall = bf.Deserialize(fs) as Wall;
            if (t == typeof(Snake))
                Game.snake = bf.Deserialize(fs) as Snake;
            if (t == typeof(Food))
                Game.food = bf.Deserialize(fs) as Food;
            fs.Close();
        }

        // TODO: The Save function (Serialization)
        // TODO: The Resume function (Deserialization)
    }
}