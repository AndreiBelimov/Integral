using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class Program
    {
        static int n;
        static double a;
        static double b;
        static double h;
        static double[] ksi;
        static double[] y;

        static double f(double x)
        {
            return x * x;
        }

        static void LeftRectangle()
        {
            double S = 0;
            for (int i = 0; i < n; i++)
            {
                S += y[i];
            }
            S *= h;
            Console.WriteLine("Метод левых прямоугольников: " + S);
        }

        static void RightRectangle()
        {
            double S = 0;
            for (int i = 1; i < n + 1; i++)
            {
                S += y[i];
            }
            S *= h;
            Console.WriteLine("Метод правых прямоугольников: " + S);
        }

        static void MiddleRectangle()
        {
            double S = 0;
            for (int i = 1; i < n + 1; i++)
            {
                S += f((ksi[i] + ksi[i - 1]) / 2);
            }
            S *= h;
            Console.WriteLine("Метод средних прямоугольников: " + S);
        }

        static void Trapeze()
        {
            double S = 0;
            for (int i = 1; i < n; i++)
            {
                S += y[i];
            }
            S = h * (S + (y[0] + y[n]) / 2);
            Console.WriteLine("Метод трапеции: " + S);
        }

        static void Simpson()
        {
            double S = 0;
            for (int i = 1; i < n; i = i + 2)
            {
                S += y[i - 1] + 4 * y[i] + y[i + 1];
            }
            S = S * h / 3;
            Console.WriteLine("Метод Симпсона: " + S);
        }

        static void Main(string[] args)
        {
            n = 10;
            a = 0;
            b = 1;
            h = (b - a) / n;
            ksi = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                ksi[i] = a + i * h;
            }
            y = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                y[i] = f(ksi[i]);
            }
            LeftRectangle();
            RightRectangle();
            MiddleRectangle();
            Trapeze();
            Simpson();
        }
    }
}
