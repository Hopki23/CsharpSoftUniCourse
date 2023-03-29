// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.Text;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.Data.Models;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";
        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            using StringReader reader = new StringReader(xmlString);
            ImportProjectDto[] projectDtos =
                (ImportProjectDto[])serializer.Deserialize(reader);

            ICollection<Project> validProjects = new HashSet<Project>();

            foreach (var p in projectDtos)
            {
                if (!IsValid(p))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidOpenDate = DateTime.TryParseExact(p.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!string.IsNullOrEmpty(p.DueDate))
                {
                    bool isValidDueDate = DateTime.TryParseExact(p.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                   out DateTime date);

                    if (!isValidDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = date;
                }

                Project project = new Project()
                {
                    Name = p.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                ICollection<Task> tasks = new HashSet<Task>();

                foreach (var t in p.Tasks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidTaskOpenDate = DateTime.TryParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                   out DateTime openTaskDate);

                    if (!isValidTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidTaskDueDate = DateTime.TryParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                   out DateTime dueTaskDate);

                    if (!isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openTaskDate.Date < openDate.Date)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue)
                    {
                        if (dueTaskDate.Date > dueDate.Value.Date)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    Task task = new Task()
                    {
                        Name = t.Name,
                        OpenDate = openTaskDate,
                        DueDate = dueTaskDate,
                        ExecutionType = (ExecutionType)t.ExecutionType,
                        LabelType = (LabelType)t.LabelType
                    };

                    tasks.Add(task);
                }
                project.Tasks = tasks;

                validProjects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name,
                    project.Tasks.Count()));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var employeeDtos =
                JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            ICollection<Employee> validEmployees = new HashSet<Employee>();

            ICollection<int> existingTasksIds = context.Tasks
                .Select(t => t.Id)
                .ToArray();

            foreach (var e in employeeDtos)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                foreach (var t in e.Tasks.Distinct())
                {
                    if (!existingTasksIds.Contains(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = t
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                }

                validEmployees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(validEmployees);
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