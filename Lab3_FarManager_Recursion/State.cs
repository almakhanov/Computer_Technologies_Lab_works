using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarWithRecursion
{
    class CustomFolderInfo
    {
        CustomFolderInfo prev;
        int index;
        DirectoryInfo[] dirs;

        public CustomFolderInfo(CustomFolderInfo prev, int index, DirectoryInfo[] directoryInfo)
        {
            this.prev = prev;
            this.index = index;
            this.dirs = directoryInfo;        }

        public void PrintFolderInfo()

        {

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < dirs.Length; ++i)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(dirs[i]);
            }
        }
        public void DecreaseIndex()
        {
            if (index - 1 >= 0)
                index--;
        }

        public void IncreaseIndex()
        {
            if (index + 1 < dirs.Length)
                index++;
        }

        public CustomFolderInfo GetNextItem()
        {
            return new CustomFolderInfo(this, 0, this.dirs[index].GetDirectories());
        }

        public CustomFolderInfo GetPrevItem()
        {
            return prev;
        }

    }

}