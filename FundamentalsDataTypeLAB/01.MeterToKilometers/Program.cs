using System;

namespace _1.MeterToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal kilometers = meters / 1000;
            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
