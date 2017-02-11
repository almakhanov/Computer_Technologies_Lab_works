using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_number
{
    class Program
    {
        static void Main(string[] args)
        { 
            int k = 0;  // counts number of / numbers
            int q = 0;  // counts prime numbers
            int[] A = new int[args.Length];
            int[] Arr = new int[1000];
            for(int i = 0; i<args.Length; i++)
            {
                Arr[i] = int.Parse(args[i]);
            }

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 1; j <= Arr[i]; j++)
                {
                    if (Arr[i] % j == 0) // checks for prime or not
                        k++;
                }

                if (k == 2) // if so then number keeps in array
                {                
                    A[q] = Arr[i];
                    q++;
                }
                k = 0;
            }
            
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(A[i] + " ");
            }
        }
    }
}
