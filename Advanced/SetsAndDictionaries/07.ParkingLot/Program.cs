using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input.Split(",");
                string command = arr[0];
                string car = arr[1];

                if (command == "IN")
                {
                    cars.Add(car);
                }
                else
                {
                    cars.Remove(car);
                }
            }
            if (cars.Count == 0)
            {
               Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
               Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
        }
    }
}
