using System;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestKeg = double.MinValue;
            string biggetsKegModel = String.Empty;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(2, radius) * height;

                if (volume > biggestKeg)
                {
                    biggestKeg = volume;
                    biggetsKegModel = model;
                }
            }
            Console.WriteLine(biggetsKegModel);
        }
    }
}
