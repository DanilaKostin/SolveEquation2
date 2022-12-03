using System;
using System.Collections.Generic;

namespace netTools
{
    class Program
    {
        private class Realization : IComparable
        {
            private const double Pi = 3.1415;
            public int CompareTo(object obj)
            {
                int radius = 12 + 1 * 3;
                Console.WriteLine(Pi * radius * radius);
                throw new NotImplementedException();
            }
        }
        public class Reform
        {
            public int IntegerProperty { get; set; }
            private static bool _flagOfUssr = false;

            public void MethodOfWork<T>(int a, int b, T generic)
            {
                List<T> list = new List<T>();
                if (_flagOfUssr)
                {
                    Console.Write(a + b);
                }
                else
                {
                    _flagOfUssr = true;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициент a");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэффициент b");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэффициент c");
            double c = double.Parse(Console.ReadLine());
            var t = new Solver().SolveEquation(a, b, c);
            Console.WriteLine(t[0]);
        }
    }
    public class Solver
    {
        public double[] SolveEquation(double a, double b, double c)
        {
            string kA = a + "x^2";
            string kB = b >= 0 ? "+" + b + "x" : b + "x";
            string kC = c >= 0 ? "+" + c : c.ToString();
            Console.WriteLine(kA + kB + kC);
            if (a == 0)
            {
                if (b == 0 && c == 0)
                    return new[] { double.PositiveInfinity };
                if (b == 0 && c != 0)
                    return new double[0];
                return new[] { -c / b };
            }
            if (a != 0)
            {
                if (b != 0)
                {
                    double discriminant = b * b - 4 * a * c;
                    if (discriminant < 0)
                        return new double[0];
                    if (discriminant == 0)
                        return new[] { -b / (2 * a) };
                    var v1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    var v2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    if (v2 < v1)
                    {
                        var temp = v1;
                        v1 = v2;
                        v2 = temp;
                    }
                    return new[] { v1, v2 };
                }
                if (a > 0 && c > 0)
                    return new double[0];
                {
                    var v1 = -Math.Sqrt(-c / a);
                    var v2 = Math.Sqrt(-c / a);
                    if (v2 < v1)
                    {
                        var temp = v1;
                        v1 = v2;
                        v2 = temp;
                    }
                    return new[] { v1, v2 };
                }
            }
            throw new Exception();
        }
    }
}

