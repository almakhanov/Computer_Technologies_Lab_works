using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeII
{
    public class Worm : GameObject
    {
        public Game game = null;
        public bool isLevel = false;

        public void LinkToGame(Game game)
        {
            this.game = game;
        }

        public int dx;
        public int dy;

        public Worm()
        {
            this.sign = '*';
            this.dx = 0;
            this.dy = 0;
        }

        public void Generate()
        {
            this.points.Add(new Point(10, 10));
        }

        public void Move()
        {
            while (true)
            {
                Thread.Sleep(Game.SPEED);

                if (points[0].x + dx < 0) continue;
                if (points[0].y + dy < 0) continue;
                if (points[0].x + dx > Game.WIDTH) continue;
                if (points[0].y + dy > Game.HEIGTH) continue;

                this.Clear();

                for (int i = points.Count - 1; i > 0; --i)
                {
                    points[i].x = points[i - 1].x;
                    points[i].y = points[i - 1].y;
                }

                points[0].x = points[0].x + dx;
                points[0].y = points[0].y + dy;

                this.Draw();
                
                
                if ((points.Count % 412) == 4 && isLevel == false)
                {
                    isLevel = true;
                    Wall wall= new Wall();
                    wall.Generate(2);
                    Console.Clear();
                    
                    
                    Load();
                    wall.Draw();
                }
                game.CanEat();
            }
        }


    }
}