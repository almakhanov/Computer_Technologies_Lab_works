using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace DRAFT
{
    [Serializable]
    public class Complex
    {
        int a, b;
        public Complex()
        {
            a = 0;
            b = 0;
        }

        public Complex(int _a, int _b)
        {
            a = _a;
            b = _b;
        }

        public int A
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }

        }

        public int B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }
        }

        public static Complex operator +(Complex x, Complex y)
        {

            Complex z = new Complex();
            z.A = x.A + y.A;
            z.B = x.B + y.B;
            return z;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFormatter bnf = new BinaryFormatter();

            Complex z1 = new Complex(1, 3);
            Complex z2 = new Complex(2, 5);
            Complex z3 = z1 + z2;

            using(FileStream fs = File.Create("ComplexBNF.data"))
            {
                bnf.Serialize(fs, z3);
            }

            using(FileStream fStr = File.OpenRead("ComplexBNF.data"))
            {
                Complex zs = new Complex();
                zs = bnf.Deserialize(fStr) as Complex;
                Console.WriteLine("z=" + zs.A + "+" + zs.B + "i");
            }

            

            Console.WriteLine("Press any key to quit");

            Console.ReadKey();

        }

    }

}