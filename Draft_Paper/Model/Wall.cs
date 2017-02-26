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
    public class Wall : Drawer
    {
        public Wall() { }

        public Wall(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            LoadLevel(1);
        }

        public void LoadLevel(int level)
        {
          // int cnt = Game.snake.body.Count;
            body.Clear();

            string filename = string.Format(@"Levels\Level{0}.txt", level);
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            int row = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                row++;
            }

            
        }


/*

        public void save()
        {
            FileStream fs = new FileStream("wall.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void deser()
        {
            FileStream fs = new FileStream("wall.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall wall = bf.Deserialize(fs) as Wall;
            this.body = wall.body;
            this.color = wall.color;
            this.sign = wall.sign;


            fs.Close();
        }
    */
    }
}