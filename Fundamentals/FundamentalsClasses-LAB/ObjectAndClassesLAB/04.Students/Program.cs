using System;
using System.Collections.Generic;

namespace Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student
                {
                    FirstName = tokens[0],
                    LastName = tokens[1],
                    Age = int.Parse(tokens[2]),
                    HomeTown = tokens[3],
                };
               students.Add(student);
            }

            string city = Console.ReadLine();
            var foundStudents = students.FindAll(student => student.HomeTown == city);

            foreach (Student student in foundStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
