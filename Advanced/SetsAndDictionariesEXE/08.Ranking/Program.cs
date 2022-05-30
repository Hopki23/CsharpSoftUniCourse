using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] arr = input.Split(":");
                if (contests.ContainsKey(arr[0]) == false)
                {
                    contests.Add(arr[0], arr[1]);
                }
            }
            SortedDictionary<string, Dictionary<string, int>> ranking = new SortedDictionary<string, Dictionary<string, int>>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "end of submissions")
            {
                string[] arr = cmd.Split("=>");
                string contest = arr[0];
                string password = arr[1];
                string username = arr[2];
                int points = int.Parse(arr[3]);

                if (contests.ContainsKey(contest) && contests.ContainsValue(password))
                {
                    if (ranking.ContainsKey(username) == false)
                    {
                        ranking.Add(username, new Dictionary<string, int>());
                    }

                    if (ranking[username].ContainsKey(contest) == false)
                    {
                        ranking[username].Add(contest, points);
                    }

                    if (ranking[username][contest] < points)
                    {
                        ranking[username][contest] = points;
                    }
                }
            }
            string bestCandidate = string.Empty;
            int bestTotalPoints = 0;
            foreach (var candidate in ranking)
            {
                int currPoint = 0;
                foreach (var item in candidate.Value)
                {
                    currPoint += item.Value;
                }

                if (currPoint > bestTotalPoints)
                {
                    bestTotalPoints = currPoint;
                    bestCandidate = candidate.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestTotalPoints} points.");

            Console.WriteLine("Ranking:");
            foreach (var candidate in ranking)
            {
                Console.WriteLine(candidate.Key);
                Console.WriteLine(string.Join(Environment.NewLine, candidate.Value
                    .OrderByDescending(x => x.Value)
                    .Select(a => $"#  {a.Key} -> {a.Value}")
                    ));
            }
        }
    }
}
