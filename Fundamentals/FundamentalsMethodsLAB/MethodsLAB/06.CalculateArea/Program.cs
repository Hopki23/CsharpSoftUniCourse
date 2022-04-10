using System;

namespace _6.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = RectangleArea(width, height);
            Console.WriteLine(area);
        }



        static double RectangleArea(double first, double second)
        {
            return first * second;
        }
    }
}
