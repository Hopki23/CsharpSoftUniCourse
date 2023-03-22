namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Coaches");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), root);
            using StringReader reader = new StringReader(xmlString);
            ImportCoachDto[] coaches =
                (ImportCoachDto[])serializer.Deserialize(reader);

            HashSet<Coach> validCoaches = new HashSet<Coach>();

            foreach (var coach in coaches)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(coach.Name)
                  || string.IsNullOrEmpty(coach.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach currCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality
                };

                HashSet<Footballer> validFootballers = new HashSet<Footballer>();

                foreach (var footballer in coach.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (string.IsNullOrEmpty(footballer.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidStartDate = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime contractStartDate);

                    if (!isValidStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidEndDate = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime contractEndDate);

                    if (!isValidEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate > contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer currFootballer = new Footballer()
                    {
                        Name = footballer.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        PositionType = (PositionType)footballer.PositionType,
                        CoachId = currCoach.Id
                    };

                    validFootballers.Add(currFootballer);
                    currCoach.Footballers.Add(currFootballer);
                }

                validCoaches.Add(currCoach);

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, validFootballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var teams =
                JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            HashSet<Team> validTeams = new HashSet<Team>();
            HashSet<Footballer> validFootballers = new HashSet<Footballer>();

            foreach (var team in teams)
            {
                if (!IsValid(team))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidTrophies = int.TryParse(team.Trophies, out int trophies);

                if (!isValidTrophies)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(team.Name) || 
                    string.IsNullOrEmpty(team.Nationality) || 
                    trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team currTeam = new Team()
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = trophies
                };

                foreach (var footballer in team.Footballers.Distinct())
                {
                    Footballer currFootballer = context.Footballers.Find(footballer);
                    if (currFootballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currTeam.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = currFootballer
                    });

                    validFootballers.Add(currFootballer);
                }              
                validTeams.Add(currTeam);

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, currTeam.Name, validFootballers.Count()));

                validFootballers.Clear();
            }

            context.Teams.AddRange(validTeams);
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
