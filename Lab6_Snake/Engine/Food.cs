using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Food : GameObject
    {
        public Food()
        {
            this.sign = '$';
        }
        public void Generate()
        {
            this.points.Add(new Point(20, 13));
        }
        public void SetRandomPosition()
        {
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 34);

            points[0] = new Point(x, y);
        }


    }
}