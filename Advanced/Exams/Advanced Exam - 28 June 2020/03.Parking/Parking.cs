using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => cars.Count;

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return cars.Remove(car);
        }
        public Car GetLatestCar()
        {
            return cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model)
        {
            return cars.FirstOrDefault(x =>x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString().TrimEnd());
            }
            return sb.ToString();
        }
    }
}
