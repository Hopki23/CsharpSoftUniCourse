using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalAmount = 0;

            while (yield >= 100)
            {
                days++;
                totalAmount += yield - 26;
                yield -= 10;
            }

            //if (days > 0)
            //{
                totalAmount -= 26;
            //}

            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}
