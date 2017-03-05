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


                if ((points.Count ) == 4 && isLevel == false)
                {
                    isLevel = true;
                    
                    Wall wall2 = new Wall();
                    
                    wall2.Generate(2);
                    Console.Clear();
                    Food f = new Food();
                    f.Generate();
                    f.Draw();
                    
                    
                    
                    wall2.Draw();                   
                    Move();            
                    
                }
                Border();
                game.CanEat();
                if (game.WC()) {
                    Console.Clear();
                    Console.WriteLine("GAMEOVER");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Please press ESC to continue the game...");
                    break;
                }
            }
        }
        public void Border()
        {
            if (points[0].x > 70) points[0].x = 1;
            if (points[0].y > 35) points[0].y = 1;
            if (points[0].x <= 0) points[0].x = 70;
            if (points[0].y <= 0) points[0].y = 35;
        }


    }
}