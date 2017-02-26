using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Snake.Engine
{
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

        public override bool Equals(object obj)
        {
            Point o = obj as Point;
            if (x == o.x && y == o.y) return true;
            return false;
        }
    }
}
