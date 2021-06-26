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
        public double Re { get; set; }
        public double Im { get; set; }
        /// <summary>
        /// комплексные числа
        /// </summary>
        /// <param name="re"></param>
        /// <param name="im"></param>
        public Complex(double re = 0, double im = 0)
        {
            Re = re; Im = im;
        }
        #region bool
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Complex c = obj as Complex;
            if (c == null) return false;
            return (Re == c.Re && Im == c.Im);
        }
        public override int GetHashCode() => Re.GetHashCode() + Im.GetHashCode();
        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, b)) return true;
            if ((object)a == null) return false;
            return a.Equals(b);
        }
        public static bool operator !=(Complex a, Complex b) => !(a == b);
        #endregion
        #region +
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im);
        public static Complex operator +(double a, Complex b) => new Complex(a) + b;
        public static Complex operator +(Complex a, double b) => b + a;
        #endregion
        #region -
        public static Complex operator -(Complex a) => new Complex(-a.Re, -a.Im);
        public static Complex operator -(Complex a, Complex b) => a + (-b);
        public static Complex operator -(double a, Complex b) => new Complex(a) - b;
        public static Complex operator -(Complex a, double b) => a + (-b);
        #endregion
        #region *
        public static Complex operator *(Complex a, Complex b) => new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        public static Complex operator *(double a, Complex b) => new Complex(a) * b;
        public static Complex operator *(Complex a, double b) => b * a;
        #endregion
        #region /
        public static Complex operator /(Complex a, Complex b)
        {
            //if (b.Re == 0 && b.Im == 0) throw new DivideByZeroException("Делитель не может быть равен нулю");
            double d = (b.Re * b.Re + b.Im * b.Im);
            return new Complex((a.Re * b.Re + a.Im * b.Im) / d, (a.Im * b.Re - a.Re * b.Im) / d);
        }
        public static Complex operator /(double a, Complex b) => new Complex(a) / b;
        public static Complex operator /(Complex a, double b) => a / new Complex(b);
        #endregion
        public void Print() => Console.WriteLine("{0} + {1}i", Re, Im);
        public override string ToString()
        {
            string result = "";
            if (Re == 0 && Im == 0) return "0";
            result += ((Re != 0) ? Re.ToString() : "");
            result += ((Im > 0) ? "+" + Im.ToString() + "i" : ((Im < 0) ? Im.ToString() + "i" : ""));
            return result.Trim();
        }
        public double Mod() => Math.Sqrt(Re * Re + Im * Im);
    }
}
