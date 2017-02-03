using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Class
{
    class Student
    {
        public string name, surname;
        public int age;
        public double gpa;

        public Student()
        {
            name = "Nur";
            surname = "Almakhanov";
            gpa = 3.33d;
            age = 18;
        }

        public override string ToString()
        {
            return this.name + " " + surname + " \nAge = " + age + "\n" + "GPA = " + gpa + "\n";
        }

        public Student(string _name, string _surname, int age, double gpa)
        {
            name = _name;
            surname = _surname;
            this.age = age;
            this.gpa = gpa;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student A = new Student();

            Student B = new Student("Borya", "Telzhanov", 18, 3.17d);

            Student C = new Student();
            C.name = "Adlet";
            C.surname = "Balzhanov";
            C.age = 18;
            C.gpa = 3.72d;

            Console.WriteLine(A.ToString());
            Console.WriteLine(B.ToString());
            Console.WriteLine(C.ToString());
            Console.ReadKey();
        }
    }
}

