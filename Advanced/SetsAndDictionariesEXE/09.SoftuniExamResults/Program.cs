using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.SoftuniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            SortedDictionary<string, int> sumbissions = new SortedDictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] arr = input.Split("-");
                string username = arr[0];
                string language = arr[1];

                if (language == "banned")
                {
                    results.Remove(username);
                }
                else
                {
                    int points = int.Parse(arr[2]);
                    if (results.ContainsKey(username) == false)
                    {
                        results.Add(username, points);                       
                    }
                    if (results[username] < points)
                    {
                        results[username] = points;
                    }
                    if (sumbissions.ContainsKey(language) == false)
                    {
                        sumbissions.Add(language, 0);
                    }
                    sumbissions[language]++;
                }
            }
            Dictionary<string, int> sortedByPoints = results
                .OrderByDescending(s => s.Value)
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var result in sortedByPoints)
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }

            Dictionary<string, int> sortedBySubmissions = sumbissions
               .Where(s => s.Value > 0)
               .OrderByDescending(s => s.Value)
               .ThenBy(s => s.Key)
               .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");

            foreach (var submission in sortedBySubmissions)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
