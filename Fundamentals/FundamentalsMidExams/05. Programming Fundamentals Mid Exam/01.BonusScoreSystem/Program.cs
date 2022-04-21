using System;

namespace BonusScoreSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberOfStudents = double.Parse(Console.ReadLine());
            double numberOfLectures = double.Parse(Console.ReadLine());
            double bonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            double mostAttendance = double.MinValue;

            for (int i = 1; i <= numberOfStudents ; i++)
            {
                int currentStudentsAttendance = int.Parse(Console.ReadLine());           
                double totalBonus =Math.Ceiling((currentStudentsAttendance / numberOfLectures) * (5 + bonus));

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    mostAttendance = currentStudentsAttendance;
                }
            }
            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {mostAttendance} lectures.");
        }
    }
}
