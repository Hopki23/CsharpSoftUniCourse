namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), new XmlRootAttribute("Plays"));
            using StringReader reader = new StringReader(xmlString);
            ImportPlayDto[] playDtos =
                (ImportPlayDto[])xmlSerializer.Deserialize(reader);

            HashSet<Play> validPlays = new HashSet<Play>();
            string[] validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };

            foreach (var play in playDtos)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validGenres.Contains(play.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(play.Title) ||
                    string.IsNullOrEmpty(play.Description) ||
                    string.IsNullOrEmpty(play.Screenwriter) ||
                    string.IsNullOrEmpty(play.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidTime = TimeSpan.TryParseExact(play.Duration, "c"
                    , CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan time);

                if (!isValidTime)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (time.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Play currPlay = new Play()
                {
                    Title = play.Title,
                    Duration = time,
                    Rating = play.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), play.Genre),
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                validPlays.Add(currPlay);
                sb.AppendLine(string.Format(SuccessfulImportPlay, currPlay.Title,
                    currPlay.Genre, currPlay.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), new XmlRootAttribute("Casts"));
            using StringReader reader = new StringReader(xmlString);
            ImportCastDto[] castDtos =
                (ImportCastDto[])xmlSerializer.Deserialize(reader);

            HashSet<Cast> validCasts = new HashSet<Cast>();

            foreach (var cast in castDtos)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(cast.FullName) ||
                    string.IsNullOrEmpty(cast.PhoneNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = context.Plays.FirstOrDefault(p => p.Id == cast.PlayId);

                if (play == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast c = new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = play.Id,
                    Play = play
                };

                validCasts.Add(c);
                sb.AppendLine(string.Format(SuccessfulImportActor, c.FullName, c.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var theatresDto =
                JsonConvert.DeserializeObject<ImportProjectionDto[]>(jsonString);
            HashSet<Theatre> validTheatres = new HashSet<Theatre>();
            HashSet<Ticket> validTickets = new HashSet<Ticket>();

            foreach (var theatre in theatresDto)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(theatre.Name) ||
                    string.IsNullOrEmpty(theatre.Director))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre t = new Theatre()
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director
                };

                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Play play = context.Plays.FirstOrDefault(p => p.Id == ticket.PlayId);

                    if (play == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket currTicket = new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        Play = play,
                        Theatre = t
                    };
                    validTickets.Add(currTicket);
                    t.Tickets.Add(currTicket);
                }

                validTheatres.Add(t);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, t.Name, t.Tickets.Count));
            }

            context.Tickets.AddRange(validTickets);
            context.Theatres.AddRange(validTheatres);
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
