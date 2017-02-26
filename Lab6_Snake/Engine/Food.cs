using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Snake.Engine
{
    public class Food : GameObject
    {
        public Point location;

        public Food()
        {
            sign = '@';
            location = new Point(new Random().Next(1, 19), new Random().Next(1, 19));
        }
        
    }
}
