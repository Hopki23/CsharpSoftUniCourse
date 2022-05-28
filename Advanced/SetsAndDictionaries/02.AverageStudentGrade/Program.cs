using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (studentGrades.ContainsKey(name) == false)
                {
                    studentGrades.Add(name, new List<decimal>());
                }
                studentGrades[name].Add(grade);
            }

            foreach (var item in studentGrades)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {item.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
