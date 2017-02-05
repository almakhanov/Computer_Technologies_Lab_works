using System;
using System.IO;

namespace CSharpConsole
{

    class Program
    {

        static void recursiveDir(string path, int level)
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = dirInfo.GetFiles();
            System.IO.DirectoryInfo[] subDirs = dirInfo.GetDirectories();
            foreach (System.IO.FileInfo i in files)
            {
                for (int j = 0; j < level * 5; j++) Console.Write(" ");
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("-----");
            foreach (System.IO.DirectoryInfo i in subDirs)
            {
                for (int j = 0; j < level * 5; j++) Console.Write(" ");
                Console.WriteLine(i.Name);
                recursiveDir(i.FullName, level + 1);
            }



        }

        static void Main(string[] args)
        {
            //recursiveDir("C:/Test1", 0);
            StreamWriter writer =
                new System.IO.StreamWriter(@"D:\input.txt", true);
            writer.WriteLine("asdasd");
            writer.Close();

            System.IO.StreamReader reader =
                new System.IO.StreamReader(@"D:\input.txt");
            string s;
            while ((s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

    }
}
