using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeII
{
    public abstract class GameObject : IDrawable
    {
        public char sign;
        public List<Point> points = new List<Point>();

        public void Draw()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
                Console.Write(sign);
                #region MENU
                Console.SetCursorPosition(71, 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("| F2 - Save");
                Console.SetCursorPosition(71, 2);
                Console.WriteLine("| Esc - Exit");
                Console.SetCursorPosition(71, 3);
                Console.WriteLine("| F3 - Release");
                Console.SetCursorPosition(71, 4);
                Console.WriteLine("| UpArrow - Move Up");
                Console.SetCursorPosition(71, 5);
                Console.WriteLine("| DownArrow - Move Down");
                Console.SetCursorPosition(71, 6);
                Console.WriteLine("| LeftArrow - Move Left");
                Console.SetCursorPosition(71, 7);
                Console.WriteLine("| RightArrow - Move Right");
                Console.SetCursorPosition(71, 8);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 9);
                Console.WriteLine("| Score - " + (points.Count%412));
                Console.SetCursorPosition(71, 10);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 11);
                Console.WriteLine("| Level - {0}", (points.Count%412) / 4 + 1);
                Console.SetCursorPosition(71, 12);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 13);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 14);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 15);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 16);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 17);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 18);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 19);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 20);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 21);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 22);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 23);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 24);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 25);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 26);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 27);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 28);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 29);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 30);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 31);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 32);
                Console.WriteLine("|");
                Console.SetCursorPosition(71, 33);
                Console.WriteLine("|");
                #endregion
            }
        }

        public void Clear()
        {
            for (int i = 0; i < points.Count; ++i)
            {
                Console.SetCursorPosition(points[i].x, points[i].y);
                Console.Write(' ');
            }
        }

        public GameObject Load()
        {
            GameObject result = null;

            string fname = this.GetType().Name;
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", fname), FileMode.Open, FileAccess.Read))
            {
                result = xs.Deserialize(fs) as GameObject;
            }

            return result;
        }

        public void Save()
        {
            string fname = this.GetType().Name;
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (FileStream fs = new FileStream(string.Format("{0}.xml", fname), FileMode.Truncate, FileAccess.ReadWrite))
            {
                xs.Serialize(fs, this);
            }
        }
    }
}