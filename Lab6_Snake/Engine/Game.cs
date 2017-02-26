using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Snake.Engine
{
    public class Game : GameObject
    {
        public Game()
        {
            Console.SetWindowPosition(21, 21);
            Console.CursorVisible = false;

        }

        public bool CanEat(Food food)
        {
            if (points[0].Equals(food.location))
            {
                points.Add(food.location);
                return true;
            }
            return false;
        }

       
    }
}
