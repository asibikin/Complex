﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    public struct ComplexDouble : System.IFormattable, System.IEquatable<ComplexDouble>
    {
        public const double Pi = 3.141592653589793238462643383279502884197169399311481966593000573842001111842089549379151d;
        public static readonly ComplexDouble I = new ComplexDouble(0d, 1d);
        public double Re { get; set; }
        public double Im { get; set; }
        public double Abs
        {
            get { return System.Math.Sqrt(this.SqrAbs); }
            set { this *= value / this.Abs; }
        }
        public double SqrAbs
        {
            get { return this.Re * this.Re + this.Im * this.Im; }
            set { this *= System.Math.Sqrt(value / this.SqrAbs); }
        }
        public double Arg
        {
            get { return System.Math.Atan2(this.Im, this.Re); }
            set
            {
                double abs = this.Abs;
                this.Re = abs * System.Math.Cos(value);
                this.Im = abs * System.Math.Sin(value);
            }
        }
        public ComplexDouble MultipleI { get { return new ComplexDouble(-this.Im, this.Re); } }
        public ComplexDouble DivideI { get { return new ComplexDouble(this.Im, -this.Re); } }
        public ComplexDouble(double x, double y) : this() { this.Re = x; this.Im = y; }
        //
        #region Методи предків System.(Object, IFormattable, IEquatable<ComplexDouble>)
        public bool Equals(ComplexDouble other) { return this.Re.Equals(other.Re) && this.Im.Equals(other.Im); }
        public override bool Equals(object obj)
        {
            try { return this.Equals((ComplexDouble)obj); }
            catch { return false; }
        }
        public override int GetHashCode() { return this.Re.GetHashCode() + this.Im.GetHashCode(); }
        public override string ToString()
        {
            return this.Re.ToString() + (this.Im < 0 ? " " : " +") + this.Im.ToString() + 'i';
        }
        public string ToString(string format, System.IFormatProvider provider)
        {
            return this.Re.ToString(format, provider) + (this.Im < 0 ? " " : " +") + this.Im.ToString(format, provider) + 'i';
        }
        #endregion
        //
        #region Тригонометричні функції
        public static ComplexDouble Exp(ComplexDouble z)
        {
            return System.Math.Exp(z.Re) * (new ComplexDouble(System.Math.Cos(z.Im), System.Math.Sin(z.Im)));
        }
        public static ComplexDouble Log(ComplexDouble z) { return Log(z, 0); }
        public static ComplexDouble Log(ComplexDouble z, int k)
        {
            return new ComplexDouble(System.Math.Log(z.Abs), z.Arg + 2d * k * Pi);
        }
        public static ComplexDouble Log(ComplexDouble z, int kz, ComplexDouble a, int ka) { return Log(z, kz) / Log(a, ka); }
        public static ComplexDouble Pow(ComplexDouble z, double n)
        {
            return System.Math.Pow(z.Abs, n) * new ComplexDouble(System.Math.Cos(z.Arg * n), System.Math.Sin(z.Arg * n));
        }
        public static ComplexDouble Pow(ComplexDouble z, ComplexDouble n) { return Pow(z, n, 0); }
        public static ComplexDouble Pow(ComplexDouble z, ComplexDouble n, int k) { return Exp(n * Log(z, k)); }
        public static ComplexDouble Sqrt(ComplexDouble z, int k) { return Pow(z, new ComplexDouble(0.5d, 0d), k); }
        //
        public static ComplexDouble Sin(ComplexDouble z) { return Sinh(z.MultipleI).DivideI; }
        public static ComplexDouble Cos(ComplexDouble z) { return Cosh(z.MultipleI); }
        public static ComplexDouble Tan(ComplexDouble z) { return Tanh(z.MultipleI).DivideI; }
        public static ComplexDouble Cot(ComplexDouble z) { return Coth(z.MultipleI).MultipleI; }
        public static ComplexDouble Sec(ComplexDouble z) { return Sech(z.MultipleI); }
        public static ComplexDouble Csc(ComplexDouble z) { return Csch(z.MultipleI).MultipleI; }
        public static ComplexDouble Sinh(ComplexDouble z) { return Sinh2(z) / 2d; }
        public static ComplexDouble Sinh2(ComplexDouble z) { return (Exp(z) - Exp(-z)); }
        public static ComplexDouble Cosh(ComplexDouble z) { return Cosh2(z) / 2d; }
        public static ComplexDouble Cosh2(ComplexDouble z) { return (Exp(z) + Exp(-z)); }
        public static ComplexDouble Tanh(ComplexDouble z) { return Sinh2(z) / Cosh2(z); }
        public static ComplexDouble Coth(ComplexDouble z) { return Cosh2(z) / Sinh2(z); }
        public static ComplexDouble Sech(ComplexDouble z) { return 2d / Cosh2(z); }
        public static ComplexDouble Csch(ComplexDouble z) { return 2d / Sinh2(z); }
        //
        public static ComplexDouble Asin(ComplexDouble z, int kLog, int kSqrt) { return Asinh(z.MultipleI, kLog, kSqrt).DivideI; }
        public static ComplexDouble Acos(ComplexDouble z, int kLog, int kSqrt) { return Acosh(z, kLog, kSqrt).DivideI; }
        public static ComplexDouble Atan(ComplexDouble z, int kLog) { return Atanh(z.DivideI, kLog).MultipleI; }
        public static ComplexDouble Acot(ComplexDouble z, int kLog) { return Atan(1d / z, kLog); }
        public static ComplexDouble Asec(ComplexDouble z, int kLog, int kSqrt) { return Acos(1d / z, kLog, kSqrt); }
        public static ComplexDouble Acsc(ComplexDouble z, int kLog, int kSqrt) { return Asin(1d / z, kLog, kSqrt); }
        public static ComplexDouble Asinh(ComplexDouble z, int kLog, int kSqrt) { return Log(z + Sqrt(z * z + 1d, kSqrt), kLog); }
        public static ComplexDouble Acosh(ComplexDouble z, int kLog, int kSqrt) { return Log(z + Sqrt(z * z - 1d, kSqrt), kLog); }
        public static ComplexDouble Atanh(ComplexDouble z, int kLog) { return Log((1d + z) / (1d - z), kLog) / 2d; }
        public static ComplexDouble Acoth(ComplexDouble z, int kLog) { return Atanh(1d / z, kLog); }
        public static ComplexDouble Asech(ComplexDouble z, int kLog, int kSqrt) { return Acosh(1d / z, kLog, kSqrt); }
        public static ComplexDouble Acsch(ComplexDouble z, int kLog, int kSqrt) { return Asinh(1d / z, kLog, kSqrt); }
        #endregion
        //
        #region Оператори
        public static ComplexDouble operator ~(ComplexDouble z) { return new ComplexDouble(z.Re, -z.Im); }
        public static ComplexDouble operator !(ComplexDouble z) { return ~z; }
        public static ComplexDouble operator ++(ComplexDouble z) { return new ComplexDouble(++z.Re, z.Im); }
        public static ComplexDouble operator --(ComplexDouble z) { return new ComplexDouble(--z.Re, z.Im); }
        public static ComplexDouble operator +(ComplexDouble z) { return z; }
        public static ComplexDouble operator -(ComplexDouble z) { return new ComplexDouble(-z.Re, -z.Im); }
        public static ComplexDouble operator +(ComplexDouble z1, ComplexDouble z2) { return new ComplexDouble(z1.Re + z2.Re, z1.Im + z2.Im); }
        public static ComplexDouble operator -(ComplexDouble z1, ComplexDouble z2) { return z1 + -z2; }
        public static ComplexDouble operator *(ComplexDouble z1, ComplexDouble z2) { return new ComplexDouble(z1.Re * z2.Re - z1.Im * z2.Im, z1.Re * z2.Im + z1.Im * z2.Re); }
        public static ComplexDouble operator /(ComplexDouble z1, ComplexDouble z2) { return z1 * ~z2 / z2.SqrAbs; }
        public static ComplexDouble operator %(ComplexDouble z1, ComplexDouble z2) { return new ComplexDouble(z1.Re % z2.Re, z1.Im % z2.Im); }
        public static ComplexDouble operator +(ComplexDouble z1, double d2) { return z1 + new ComplexDouble(d2, 0d); }
        public static ComplexDouble operator -(ComplexDouble z1, double d2) { return z1 + -d2; }
        public static ComplexDouble operator *(ComplexDouble z1, double d2) { return new ComplexDouble(z1.Re * d2, z1.Im * d2); }
        public static ComplexDouble operator %(ComplexDouble z1, double d2) { return z1 % new ComplexDouble(d2, 0d); }
        public static ComplexDouble operator /(ComplexDouble z1, double d2) { return z1 * (1d / d2); }
        public static ComplexDouble operator +(double d1, ComplexDouble z2) { return z2 + d1; }
        public static ComplexDouble operator -(double d1, ComplexDouble z2) { return -z2 + d1; }
        public static ComplexDouble operator *(double d1, ComplexDouble z2) { return z2 * d1; }
        public static ComplexDouble operator /(double d1, ComplexDouble z2) { return new ComplexDouble(d1, 0d) / z2; }
        public static ComplexDouble operator %(double d1, ComplexDouble z2) { return new ComplexDouble(d1, 0d) % z2; }
        public static bool operator ==(ComplexDouble z1, ComplexDouble z2) { return z1.Equals(z2); }
        public static bool operator !=(ComplexDouble z1, ComplexDouble z2) { return !z1.Equals(z2); }
        public static explicit operator ComplexDouble(double d) { return new ComplexDouble(d, 0d); }
        #endregion
    }
}