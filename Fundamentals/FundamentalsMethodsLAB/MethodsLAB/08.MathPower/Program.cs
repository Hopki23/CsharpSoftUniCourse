using System;

namespace _8.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Pow(first, second));
        }
    }
}
