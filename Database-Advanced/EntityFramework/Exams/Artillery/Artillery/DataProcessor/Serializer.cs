
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .ToArray()
                .Select(s => new
                {
                    s.ShellWeight,
                    s.Caliber,
                    Guns = s.Guns
                            .Where(x => ((int)x.GunType) == 3)
                            .Select(g => new
                            {
                                GunType = g.GunType.ToString(),
                                g.GunWeight,
                                g.BarrelLength,
                                Range = g.Range > 3000 ? "Long-range" : "Regular range"
                            })
                            .OrderByDescending(g => g.GunWeight)
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            StringBuilder sb = new StringBuilder();
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .ToArray()
                .Select(g => new ExportGunDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength,
                    GunWeight = g.GunWeight,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                                .Where(c => c.Country.ArmySize > 4500000)
                                .Select(c => new ExportCountryDto()
                                {
                                    Country = c.Country.CountryName,
                                    ArmySize = c.Country.ArmySize
                                })
                                .OrderBy(c => c.ArmySize)
                                .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportGunDto[]), new XmlRootAttribute("Guns"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, guns, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
