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
    public class Point
    {
        public int x;
        public int y;

        public Point() { }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }


   /* public void save()
    {
        FileStream fs = new FileStream("point.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, this);
        fs.Close();
    }

    public void deser()
    {
        FileStream fs = new FileStream("point.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        BinaryFormatter bf = new BinaryFormatter();
        Point p = bf.Deserialize(fs) as Point;
        this.body = snake.body;
        this.color = snake.color;
        this.sign = snake.sign;


        fs.Close();
    }
    */
}