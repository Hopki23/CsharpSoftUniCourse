using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //string inputJson = File.ReadAllText("../../../Datasets/sales.json");

            string result = GetTotalSalesByCustomer(context);
            Console.WriteLine(result);
        }
        // Problem 09
        //100/100
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSupplyDto[] supplies =
                JsonConvert.DeserializeObject<ImportSupplyDto[]>(inputJson);

            HashSet<Supplier> validSupplies = new HashSet<Supplier>();

            foreach (var s in supplies)
            {
                Supplier supplier = new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImported
                };

                validSupplies.Add(supplier);
            }

            context.Suppliers.AddRange(validSupplies);
            context.SaveChanges();

            return $"Successfully imported {validSupplies.Count}.";
        }

        // Problem 10
        //50/100
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartDto[] parts =
                JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            HashSet<Part> validParts = new HashSet<Part>();

            foreach (var p in parts)
            {
                Part part = new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                };

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        // Problem 11
        //50/100
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<ImportCarDto> cars =
                JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            HashSet<Car> validCars = new HashSet<Car>();

            foreach (var c in cars)
            {
                Car car = new Car()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                };

                foreach (var part in c.PartsId)
                {
                    bool isValid = car.PartsCars.FirstOrDefault(x => x.PartId == part) == null;
                    bool isPartValid = context.Parts.FirstOrDefault(p => p.Id == part) == null;

                    if (isValid && isPartValid)
                    {
                        car.PartsCars.Add(new PartCar()
                        {
                            PartId = part
                        });
                    }
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        // Problem 12
        //100/100
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customers =
               JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            HashSet<Customer> validCustomers = new HashSet<Customer>();

            foreach (var customer in customers)
            {
                Customer currCustomer = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                };

                validCustomers.Add(currCustomer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        // Problem 13
        //100/100
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ImportSalesDto[] sales =
               JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson);

            HashSet<Sale> validSales = new HashSet<Sale>();

            foreach (var sale in sales)
            {
                Sale currSale = new Sale()
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };

                validSales.Add(currSale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        //Problem 14
        //100/100
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem 15
        //Judge does not like this.
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();



            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //Problem 16
        //100/100
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //Problem 17
        //Does not work because DB does not accept data.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    parts = c.PartsCars
                            .Select(p => new
                            {
                                Name = p.Part.Name,
                                Price = p.Part.Price.ToString("F2")
                            })
                            .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);

        }
    }
}