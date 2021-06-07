using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 1;
            Complex z = new Complex(a, b);
            Console.WriteLine("z = {0}", z);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 = z - (z * z * z - 1) / (3 * z * z) = {0}", z1);
            Console.WriteLine("z+z = {0}", z + z);
            Console.WriteLine("z-z = {0}", z - z);
            Console.WriteLine("z*z = {0}", z * z);
            Console.WriteLine("z/z = {0}", z / z);
            //Console.WriteLine("|z| = {0}", z.Mod());
            Console.WriteLine("z = z1- {0}",  z == z1);
            Console.WriteLine("z/0 = {0}", z / 0);
            
            /*Console.WriteLine("z({1},{2}) = {0}", new Complex(b, b), b, b);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(a, b), a, b);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(b, a), b, a);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(a, a), a, a);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(-a, b), -a, b);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(b, -a), b, -a);
            Console.WriteLine("z({1},{2}) = {0}", new Complex(-a, -a), -a, - a);
            */
            Console.ReadLine();
        }
    }
}
