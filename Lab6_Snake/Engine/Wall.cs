using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Wall : GameObject
    {
        public Wall()
        {
            this.sign = '#';
            Generate(Game.LEVEL);
        }
        public void Generate(int level)
        {
            points.Clear();
            string fname = string.Format("Levels/level{0}.txt", level);

            using (FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = "";
                    int row = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        for (int col = 0; col < line.Length; col++)
                        {
                            if (line[col] == '#')
                            {
                                points.Add(new Point(col, row));
                            }
                        }
                        row++;
                    }
                }
            }
        }
    }
}