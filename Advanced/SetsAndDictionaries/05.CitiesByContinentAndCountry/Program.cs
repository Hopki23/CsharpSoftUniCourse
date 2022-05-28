using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                string continent = arr[0];
                string country = arr[1];
                string countryCity = arr[2];

                if (dictionary.ContainsKey(continent) == false)
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                }

                if (dictionary[continent].ContainsKey(country) == false)
                {
                    dictionary[continent].Add(country, new List<string>());
                }

                dictionary[continent][country].Add(countryCity);
            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
