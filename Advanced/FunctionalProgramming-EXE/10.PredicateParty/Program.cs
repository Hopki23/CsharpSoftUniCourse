using System;
using System.Linq;

namespace _10.PredictParty
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var namesList = Console.ReadLine()
                .Split()
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var tokens = command.Split().ToList();

                var predicate = GetPredicate(tokens[1], tokens[2]);

                switch (tokens[0])
                {
                    case "Remove":
                        namesList.RemoveAll(predicate);
                        break;
                    case "Double":
                        {
                            var matches = namesList.FindAll(predicate);
                            if (matches.Count > 0)
                            {
                                var index = namesList.FindIndex(predicate);
                                namesList.InsertRange(index, matches);
                            }

                            break;
                        }
                }
            }

            if (namesList.Count != 0)
            {
                Console.WriteLine(string.Join(", ", namesList) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + commandType);
            }
        }
    }
}