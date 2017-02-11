using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MAX
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] lines = File.ReadAllLines(@"D:\input.txt");

            Console.WriteLine("Contents of Input.txt = " + "\n");

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            
            int maxi = 0;
            int mini = 1000000;
            
            for (int i = 0; i < lines.Length; i++)

            {
                if (maxi < int.Parse(lines[i]))
                {
                    maxi = int.Parse(lines[i]);
                }
                if (mini > int.Parse(lines[i]))
                {
                    mini = int.Parse(lines[i]);
                }
            }

            Console.WriteLine("\n" + "Max number is: " + maxi);
            Console.WriteLine("\n" + "Min number is: " + mini + "\n");

            Console.WriteLine("Press any key to exit.");

            System.Console.ReadKey();            
        }

    }

}
