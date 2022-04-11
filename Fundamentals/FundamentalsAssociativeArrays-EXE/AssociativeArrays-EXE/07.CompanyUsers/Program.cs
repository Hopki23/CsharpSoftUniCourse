using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" -> ");
                string companyName = tokens[0];
                string id = tokens[1];

                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                }

                if (company[companyName].Contains(id))
                {
                    continue;
                }
                company[companyName].Add(id);
            }


            foreach (var item in company)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
