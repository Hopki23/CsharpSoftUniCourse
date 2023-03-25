namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Despatchers");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportDespatcherDto[]), root);
            using StringReader reader = new StringReader(xmlString);
            ImportDespatcherDto[] despatcherDtos =
                (ImportDespatcherDto[])serializer.Deserialize(reader);

            HashSet<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var despatcher in despatcherDtos)
            {
                if (!IsValid(despatcher))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(despatcher.Name) ||
                    string.IsNullOrEmpty(despatcher.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher currDespatcher = new Despatcher()
                {
                    Name = despatcher.Name,
                    Position = despatcher.Position
                };

                foreach (var truck in despatcher.Trucks)
                {
                    if (!IsValid(truck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (string.IsNullOrEmpty(truck.VinNumber) ||
                        string.IsNullOrEmpty(truck.RegistrationNumber))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!truck.TankCapacity.HasValue ||
                        !truck.CargoCapacity.HasValue)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck currTruck = new Truck()
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity.Value,
                        CargoCapacity = truck.CargoCapacity.Value,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType,
                        DespatcherId = currDespatcher.Id
                    };

                    currDespatcher.Trucks.Add(currTruck);
                }

                validDespatchers.Add(currDespatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, currDespatcher.Name,
                    currDespatcher.Trucks.Count()));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var clientsDto =
                JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            HashSet<Client> validClients = new HashSet<Client>();

            foreach (var client in clientsDto)
            {
                if (!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(client.Name) ||
                    string.IsNullOrEmpty(client.Nationality) ||
                    string.IsNullOrEmpty(client.Type))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (client.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client currClient = new Client()
                {
                    Name = client.Name,
                    Nationality = client.Nationality,
                    Type = client.Type,
                };

                foreach (var truck in client.Trucks.Distinct())
                {
                    Truck currTruck = context.Trucks.Find(truck);

                    if (currTruck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currClient.ClientsTrucks.Add(new ClientTruck()
                    {
                        Truck = currTruck
                    });
                }

                validClients.Add(currClient);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, currClient.Name,
                    currClient.ClientsTrucks.Count()));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}