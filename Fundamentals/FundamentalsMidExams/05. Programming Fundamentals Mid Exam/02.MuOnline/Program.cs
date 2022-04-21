using System;
using System.Collections.Generic;
using System.Linq;

namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            int startingHealth = 100;
            int health = 100;
            int bitcoins = 0;


            for (int i = 0; i < array.Length; i++)
            {
                string[] commands = array[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0];
                int number = int.Parse(commands[1]);

                if (direction == "potion")
                {
                    int counter = 0;
                    if (health + number > startingHealth)
                    {
                        while (true)
                        {
                            if (health == startingHealth)
                            {
                                break;
                            }
                            health++;
                            counter++;
                        }
                        Console.WriteLine($"You healed for {counter} hp.");   //WATCHOUT!
                    }
                    else
                    {
                        health += number;
                        Console.WriteLine($"You healed for {number} hp.");   //WATCHOUT!
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (direction == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    health -= number;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {direction}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {direction}.");
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
