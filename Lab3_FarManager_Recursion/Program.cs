using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarWithRecursion

{

    class Program

    {
        static void ShowFolderInfo(CustomFolderInfo item)
        {
            item.PrintFolderInfo();

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                item.DecreaseIndex();
                ShowFolderInfo(item);
            }

            else if (pressedKey.Key == ConsoleKey.DownArrow)

            {              
                item.IncreaseIndex();
                ShowFolderInfo(item);
            }

            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                CustomFolderInfo newItem = item.GetNextItem();
                ShowFolderInfo(newItem);
            }
            else if (pressedKey.Key == ConsoleKey.Escape)
            {
                CustomFolderInfo newItem = item.GetPrevItem();
                ShowFolderInfo(newItem);
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            CustomFolderInfo test = new CustomFolderInfo(null, 0, new DirectoryInfo(@"C:\").GetDirectories());
            ShowFolderInfo(test);
        }

    }

}
