using System;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] commands = Console.ReadLine().Split(" ");
                string command = commands[0];
                string username = commands[1];

                if (command == "register")
                {
                    string licensePlateNumber = commands[2];
                    if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else if (parking.ContainsKey(username) == false)
                    {
                        parking.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (parking.ContainsKey(username) == false)
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                        parking.Remove(username);
                    }
                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
