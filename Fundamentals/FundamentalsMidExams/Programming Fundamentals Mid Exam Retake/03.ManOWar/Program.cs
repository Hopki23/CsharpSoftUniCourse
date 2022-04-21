using System;
using System.Linq;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] warship = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maximumHealth = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "Retire")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int damage = int.Parse(commands[2]);

                    if (index < 0 || index > warship.Length)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    for (int i = 0; i < warship.Length; i++)
                    {
                        if (i == index)
                        {
                            warship[index] -= damage;
                            if (warship[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int damage = int.Parse(commands[3]);

                    if (startIndex < 0 || endIndex > pirateShip.Length)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        pirateShip[i] -= damage;
                        if (pirateShip[i] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);

                    if (index < 0 || index > pirateShip.Length)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (i == index)
                        {
                            if (pirateShip[index] + health > maximumHealth)
                            {
                                while (pirateShip[index] != maximumHealth)
                                {
                                    pirateShip[index]++;
                                }
                            }
                            else
                            {
                                pirateShip[index] += health;
                            }
                        }
                    }
                }
                else if (command == "Status")
                {
                    int counter = 0;

                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if (pirateShip[i] < maximumHealth - maximumHealth * 0.80)
                        {
                            counter++;
                        }
                    }
                    Console.WriteLine($"{counter} sections need repair.");
                }
                input = Console.ReadLine();
            }

            int piratesSum = 0;
            int warshipSum = 0;
            for (int i = 0; i < pirateShip.Length; i++)
            {
                piratesSum += pirateShip[i];
            }
            for (int i = 0; i < warship.Length; i++)
            {
                warshipSum += warship[i];
            }

            Console.WriteLine($"Pirate ship status: {piratesSum}");
            Console.WriteLine($"Warship status: {warshipSum}");
        }
    }
}
