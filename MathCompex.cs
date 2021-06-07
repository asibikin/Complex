using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public static int i = -1;
        public double X { get; set; }
        public double Y { get; set; }
        public Complex(double x = 0, double y = 0)
        {
            X = x; Y = y;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Complex a = obj as Complex;
            if (a == null) return false;
            return (X == a.X && Y == a.Y);
        }
        public override int GetHashCode() => ((Int32)X ^ (Int32)Y);
        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, b)) return true;
            if ((object)a == null) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Complex a, Complex b) => !(a == b);
        public static Complex operator +(Complex a, Complex b) => new Complex(a.X + b.X, a.Y + b.Y);
        public static Complex operator +(double a, Complex b) => new Complex(a) + b;
        public static Complex operator +(Complex a, double b) => b + a;

        public static Complex operator -(Complex a) => new Complex(-a.X, -a.Y);
        public static Complex operator -(Complex a, Complex b) => a + (-b);
        public static Complex operator -(double a, Complex b) => new Complex(a) - b;
        public static Complex operator -(Complex a, double b) => a + (-b);

        public static Complex operator *(Complex a, Complex b) => new Complex(a.X * b.X - a.Y * b.Y, a.X * b.Y + a.Y * b.X);
        public static Complex operator *(double a, Complex b) => new Complex(a) * b;
        public static Complex operator *(Complex a, double b) => b * a;
        
        public static Complex operator /(Complex a, Complex b)
        {
            try
            {
                if (b.X == 0 && b.Y == 0) throw new DivideByZeroException("Делитель не может быть равен нулю");
            }
            catch (DivideByZeroException e)
            {
               // Console.WriteLine("Ошибка: {0}", e.Message);
            }

            double d = (b.X * b.X + b.Y * b.Y);
            return new Complex((a.X * b.X + a.Y * b.Y) / d, (a.Y * b.X - a.X * b.Y) / d);
        }
        public static Complex operator /(double a, Complex b) => new Complex(a) / b;
        public static Complex operator /(Complex a, double b) => a / new Complex(b);

        public void Print() => Console.WriteLine("{0} + {1}i", X, Y);
        public override string ToString()
        {
            string s = "";
            if (X == 0 && Y == 0) return "0";
            s += ((X != 0) ? X.ToString() : "");
            s += ((Y > 0) ? "+" + Y.ToString() + "i" : ((Y < 0) ? Y.ToString() + "i" : ""));
            return s.Trim();
        }
        public double Mod() => Math.Sqrt(X * X + Y * Y);
    }
}
