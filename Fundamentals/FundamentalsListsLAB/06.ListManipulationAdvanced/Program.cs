using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            string input;
            bool isValid = false;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input.Split().ToArray();
                string command = cmdArgs[0];
                if (command == "Add")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.Add(number);
                    isValid = true;
                }
                else if (command == "Remove")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.Remove(number);
                    isValid = true;
                }
                else if (command == "RemoveAt")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.RemoveAt(number);
                    isValid = true;
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    list.Insert(index, number);
                    isValid = true;
                }

                if (command == "Contains")
                {
                    Contains(list, cmdArgs);
                }
                if (command == "PrintEven")
                {
                    PrintEven(list);
                }
                if (command == "PrintOdd")
                {
                    PrintOdd(list);
                }
                if (command == "GetSum")
                {
                    PrinSum(list);
                }
                if (command == "Filter")
                {
                    List<int> numbers = new List<int>();
                    string condition = cmdArgs[1];
                    int number = int.Parse(cmdArgs[2]);
                    PrintCondition(list, numbers, condition, number);
                }
            }
            if (isValid)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {

            }
        }

        static void PrintCondition(List<int> list, List<int> numbers, string condition, int number)
        {
            if (condition == "<")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] < number)
                    {
                        numbers.Add(list[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > number)
                    {
                        numbers.Add(list[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] >= number)
                    {
                        numbers.Add(list[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] <= number)
                    {
                        numbers.Add(list[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void PrinSum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            Console.WriteLine(sum);
        }

        static void PrintOdd(List<int> list)
        {
            List<int> evenNums = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    evenNums.Add(list[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNums));
        }
        static void PrintEven(List<int> list)
        {
            List<int> evenNums = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    evenNums.Add(list[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNums));
        }
        static void Contains(List<int> list, string[] cmdArgs)
        {
            bool isFound = false;
            int number = int.Parse(cmdArgs[1]);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == number)
                {
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No such number");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }
    }
}
