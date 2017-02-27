using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;

namespace Lab5_Snake
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();


        public Drawer() { }

        public Drawer(ConsoleColor color, char sign, List<Point> body)
        {
            this.body = body;
            this.color = color;
            this.sign = sign;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);                
            }
        }

        public void Save()
        {
            string fname = this.GetType().Name;
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", fname), FileMode.Truncate, FileAccess.ReadWrite))
            {
                xs.Serialize(fs, this);
            }
        }
        public void Continue()
        {
            Type type = this.GetType();
            XmlSerializer xs = new XmlSerializer(GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", type.Name), FileMode.Open, FileAccess.Read))
            {
                if(type == typeof(Worm))
                {
                    Game.snake = xs.Deserialize(fs) as Worm;
                }
                if(type == typeof(Wall))
                {
                    Game.wall = xs.Deserialize(fs) as Wall;
                }
                if(type == typeof(Food))
                {
                    Game.food = xs.Deserialize(fs) as Food;
                }
            }
        }

        
    }
}
