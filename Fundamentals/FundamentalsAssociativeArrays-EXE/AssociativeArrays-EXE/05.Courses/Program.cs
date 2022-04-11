using System;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string course = commands[0];
                string studentName = commands[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(studentName);
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var studentName in course.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
