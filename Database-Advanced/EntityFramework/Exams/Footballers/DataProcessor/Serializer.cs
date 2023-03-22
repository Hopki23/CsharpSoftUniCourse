namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        //Footballers = c.Footballers.
        //                OrderBy(f => f.Name)
        //                .Select(f => new
        //                {
        //                    f.Name,
        //                    Position = f.PositionType.ToString()
        //                })
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            StringBuilder sb = new StringBuilder();

            var coachesWithFootballers = context.Coaches
                    .Where(c => c.Footballers.Any())
                    .OrderByDescending(c => c.Footballers.Count)
                    .ThenBy(c => c.Name)
                    .Select(c => new ExportCoachDto()
                    {
                        Name = c.Name,
                        FootballersCount = c.Footballers.Count,
                        Footballers = c.Footballers.
                                Select(f => new ExportFootballerDto
                                {
                                    Name = f.Name,
                                    Position = f.PositionType.ToString()
                                })
                                .OrderBy(f => f.Name)
                                .ToArray()
                    })
                    .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportCoachDto[]), new XmlRootAttribute("Coaches"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, coachesWithFootballers, namespaces);

            return sb.ToString().TrimEnd();
        }


        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var footballers = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                                .Where(tf => tf.Footballer.ContractStartDate >= date)
                                .ToArray()
                                .OrderByDescending(f => f.Footballer.ContractEndDate)
                                .ThenBy(f => f.Footballer.Name)
                                .Select(tf => new
                                {
                                    FootballerName = tf.Footballer.Name,
                                    ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                                    ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                    BestSkillType = tf.Footballer.BestSkillType.ToString(),
                                    PositionType = tf.Footballer.PositionType.ToString()
                                })
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(footballers, Formatting.Indented);
        }
    }
}
