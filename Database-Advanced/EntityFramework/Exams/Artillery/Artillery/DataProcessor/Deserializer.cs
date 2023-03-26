namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportCountryDto[]), new XmlRootAttribute("Countries"));

            using StringReader reader = new StringReader(xmlString);

            ImportCountryDto[] countryDtos = (ImportCountryDto[])serializer.Deserialize(reader);

            HashSet<Country> countries = new HashSet<Country>();

            foreach (var country in countryDtos)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(country.CountryName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (country.ArmySize < 50_000 ||
                    country.ArmySize >= 10_000_000)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country c = new Country()
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize,
                };

                countries.Add(c);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName,
                    country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportManufacturerDto[]), new XmlRootAttribute("Manufacturers"));

            using StringReader reader = new StringReader(xmlString);

            ImportManufacturerDto[] manufacturerDtos =
                (ImportManufacturerDto[])serializer.Deserialize(reader);

            HashSet<Manufacturer> manufacturers = new HashSet<Manufacturer>();

            foreach (var man in manufacturerDtos.DistinctBy(m => m.ManufacturerName))
            {
                if (!IsValid(man))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(man.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = man.ManufacturerName
                };

                foreach (var f in man.Founded.Split(", "))
                {
                    if (string.IsNullOrEmpty(f))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    manufacturer.Founded = f;
                }

                manufacturers.Add(manufacturer);

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, manufacturer.Founded));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ImportShellDto[]), new XmlRootAttribute("Shells"));

            using StringReader reader = new StringReader(xmlString);

            ImportShellDto[] shellDtos =
                (ImportShellDto[])serializer.Deserialize(reader);

            HashSet<Shell> shells = new HashSet<Shell>();

            foreach (var shell in shellDtos)
            {

                if (!IsValid(shell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(shell.Caliber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell s = new Shell()
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber
                };

                shells.Add(s);
                sb.AppendLine(string.Format(SuccessfulImportShell, s.Caliber, s.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            StringBuilder sb = new StringBuilder();
            var guns =
                JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);
            HashSet<Gun> validGuns = new HashSet<Gun>();

            foreach (var g in guns)
            {
                if (!IsValid(g) ||
                    !validGunTypes.Contains(g.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = g.ManufacturerId,
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    NumberBuild = g.NumberBuild,
                    Range = g.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), g.GunType),
                    ShellId = g.ShellId
                };

                foreach (var c in g.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun()
                    {
                        CountryId = c.Id,
                        Gun = gun
                    });
                }

                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}