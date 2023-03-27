namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls &&
                       t.Tickets.Count() >= 20)
                .ToArray()
                .OrderByDescending(t => t.NumberOfHalls)
                .ThenBy(t => t.Name)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome =
                            t.Tickets.Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                            .Sum(s => s.Price),
                    Tickets = t.Tickets.Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                    .Select(tc => new
                    {
                        Price = tc.Price,
                        tc.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                })
                .ToArray();

            //F2 to tickets price if wrong in judge
            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            var plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Select(c => new ExportActorDto()
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer =
                new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            serializer.Serialize(writer, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
