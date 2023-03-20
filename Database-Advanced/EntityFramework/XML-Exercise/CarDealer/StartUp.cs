using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utils;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(result);
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            ImportSupplierDto[] suppliers =
                        helper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            HashSet<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var s in suppliers)
            {
                if (string.IsNullOrEmpty(s.Name))
                {
                    continue;
                }

                Supplier supplier = new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                };

                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            var parts =
                    helper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
            HashSet<Part> validParts = new HashSet<Part>();

            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part.Name))
                {
                    continue;
                }

                if (!part.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    continue;
                }

                Part currPart = new Part()
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId.Value
                };

                validParts.Add(currPart);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            var cars = helper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
            HashSet<Car> validCars = new HashSet<Car>();

            foreach (var car in cars)
            {
                if (string.IsNullOrEmpty(car.Make) ||
                   string.IsNullOrEmpty(car.Model))
                {
                    continue;
                }

                Car currCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TraveledDistance = car.TraveledDistance
                };

                foreach (var part in car.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == part.PartId))
                    {
                        continue;
                    }

                    PartCar currPart = new PartCar()
                    {
                        PartId = part.PartId
                    };

                    currCar.PartsCars.Add(currPart);
                }

                validCars.Add(currCar);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            var customers = helper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
            HashSet<Customer> validCustomers = new HashSet<Customer>();

            foreach (var customer in customers)
            {
                if (string.IsNullOrEmpty(customer.Name) ||
                   string.IsNullOrEmpty(customer.BirthDate))
                {
                    continue;
                }

                var parsedDate = DateTime.Parse(customer.BirthDate);

                Customer currCustomer = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = parsedDate,
                    IsYoungDriver = customer.IsYoungDriver
                };

                validCustomers.Add(currCustomer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            var sales = helper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
            HashSet<Sale> validSales = new HashSet<Sale>();

            ICollection<int> dbCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            foreach (var sale in sales)
            {
                if (!sale.CarId.HasValue ||
                    dbCarIds.All(id => id != sale.CarId.Value))
                {
                    continue;
                }

                Sale currSale = new Sale()
                {
                    CarId = sale.CarId.Value,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };

                validSales.Add(currSale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlHelper helper = new XmlHelper();

            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .Take(10)
                .ToArray();


            return helper.Serialize(cars, "cars");
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bwmCars = context.Cars
                .Where(c => c.Make == "BMW".ToUpper())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportBMWCarDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            XmlHelper helper = new();

            return helper.Serialize(bwmCars, "cars");
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarWithPartDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(p => new ExportPartCarDto() 
                    { 
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlHelper xmlHelper = new();

            return xmlHelper.Serialize(cars, "cars");
        }
    }
}