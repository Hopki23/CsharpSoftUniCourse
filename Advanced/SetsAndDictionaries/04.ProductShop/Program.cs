using System;
using System.Collections.Generic;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopping = new SortedDictionary<string,Dictionary<string, double>>();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] arr = input.Split(", ");
                string shop = arr[0];
                string product = arr[1];
                double price = double.Parse(arr[2]);

                if (shopping.ContainsKey(shop) == false)
                {
                    shopping.Add(shop, new Dictionary<string, double>());
                }

                shopping[shop].Add(product, price);
            }
            foreach (var shop in shopping)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
