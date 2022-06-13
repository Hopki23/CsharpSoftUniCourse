using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guestCapacity = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> plate = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedFood = 0;

            while (guestCapacity.Count > 0 && plate.Count > 0)
            {
                int currentGuest = guestCapacity.Peek();
                int currentPlate = plate.Peek();

                if (currentPlate - currentGuest >= 0)
                {
                    wastedFood += currentPlate - currentGuest;
                    guestCapacity.Dequeue();
                    plate.Pop();
                }
                else if (currentPlate - currentGuest < 0)
                {
                    while (true)
                    {
                        currentGuest -= currentPlate;
                        if (currentGuest <= 0)
                        {
                            wastedFood +=Math.Abs(currentGuest);
                            break;
                        }
                        plate.Pop();
                       currentPlate = plate.Peek();
                    }
                    guestCapacity.Dequeue();
                    plate.Pop();
                }
            }

            if (guestCapacity.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plate)}");
            }
            else if (plate.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestCapacity)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
