using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skis;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            skis = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => skis.Count;

        public void Add(Ski ski)
        {
            if (skis.Count < Capacity)
            {
                skis.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = skis.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
            return skis.Remove(ski);
        }

        public Ski GetNewestSki()
        {
            Ski ski = skis.OrderByDescending(x => x.Year).FirstOrDefault();
            return ski;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return skis.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in skis)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
