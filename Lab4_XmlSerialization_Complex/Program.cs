using System;
using System.IO;
using System.Xml.Serialization;


namespace DRAFT
{
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
            XmlSerializer xs = new XmlSerializer(typeof(Complex));

            FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Complex z1 = new Complex(1, 3);
            Complex z2 = new Complex(2, 5);
            Complex z3 = z1 + z2;

            xs.Serialize(fs, z3);

            fs.Close();

            Complex z4 = new Complex();
            FileStream fs2 = new FileStream("complex.txt", FileMode.Open, FileAccess.Read);

            z4 = xs.Deserialize(fs2) as Complex;

            Console.WriteLine("Z=" + z4.A + "+" + z4.B + "i");

            fs2.Close();


            Console.WriteLine("Press any key to quit");

            Console.ReadKey();

        }

    }

}
