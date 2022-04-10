using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            PrintPrice(product, quantity);
        }

        static void PrintPrice(string productName, double productPrice)
        {
            double price = 0;
            if (productName == "coffee")
            {
                price = productPrice * 1.50;
            }
            else if (productName == "water")
            {
                price = productPrice * 1.00;
            }
            else if (productName == "coke")
            {
                price = productPrice * 1.40;
            }
            else if (productName == "snacks")
            {
                price = productPrice * 2.00;
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
