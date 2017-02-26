using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Snake.Engine
{
    class Worm : GameObject
    {
        Game game = null;
        
        public void LinkToGame(Game game)
        {
            this.game = game;
        }

        public int dx;
        public int dy;

        public Worm()
        {
            sign = 'o';
            dx = 0;
            dy = 0;
        }

        public void Generate()
        {
            points.Add(new Point(10, 10));
        }

        public void Move()
        {
            while (IsAlive)
            {
                if (points[0].x + dx < 0) continue;
                if (points[0].y + dy < 0) continue;
                if (points[0].x + dx > 20) continue;
                if (points[0].x + dx > 20) continue;

                Clear();

                for(int i = points.Count - 1; i > 0; i--)
                {
                    points[i].x = points[i - 1].x;
                    points[i].y = points[i - 1].y;
                }

                points[0].x = points[0].x + dx;
                points[0].y = points[0].y + dy;

                Draw();

                game.CanEat(food);
            }
        }
    }
}
