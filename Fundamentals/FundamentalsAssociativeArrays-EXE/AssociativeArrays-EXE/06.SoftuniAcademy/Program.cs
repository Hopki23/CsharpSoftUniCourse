using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(studentName))
                {
                    dictionary.Add(studentName, new List<double>());
                }
                dictionary[studentName].Add(studentGrade);
            }

            foreach (var student in dictionary)
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                }
            }
        }
    }
}
