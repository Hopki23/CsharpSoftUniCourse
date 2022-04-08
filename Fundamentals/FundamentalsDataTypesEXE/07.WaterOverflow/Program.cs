using System;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            int totalWater = 0; 

            for (int i = 0; i < n; i++)
            {
                int quantity = int.Parse(Console.ReadLine());
                totalWater += quantity;

                if (totalWater > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalWater -= quantity;                  
                }
            }
            Console.WriteLine(totalWater);
        }
    }
}
