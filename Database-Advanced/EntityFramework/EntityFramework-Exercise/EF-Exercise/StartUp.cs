using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;
public class StartUp
{
    static void Main(string[] args)
    {

        SoftUniContext dbContext = new SoftUniContext();
        string result = GetEmployeesByFirstNameStartingWithSa(dbContext);

        Console.WriteLine(result);
    }

    //Problem 03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} – {e.Salary}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 05.
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 06.
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        employee!.Address = address;

        context.SaveChanges();

        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, employees);
    }

    // Problem 07.
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                           .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                        ep.Project.StartDate.Year <= 2003)
                           .Select(ep => new
                           {
                               ProjectName = ep.Project.Name,
                               StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                               EndDate = ep.Project.EndDate.HasValue ?
                               ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                               "not finished"
                           })
                           .ToArray()
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var pr in e.Projects)
            {
                sb.AppendLine($"--{pr.ProjectName} - {pr.StartDate} - {pr.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 08.
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Addresses
            .OrderByDescending(e => e.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                Text = a.AddressText,
                Town = a.Town.Name,
                EmployeesCount = a.Employees.Count
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.Text}, {e.Town} - {e.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 09.
    public static string GetEmployee147(SoftUniContext context)
    {
        var sb = new StringBuilder();


        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                            .Select(p => new
                            {
                                p.Project.Name
                            })
                            .OrderBy(p => p.Name)
                            .ToArray()
            })
            .ToArray();


        foreach (var e in employee)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

            foreach (var p in e.Projects)
            {
                sb.AppendLine($"{p.Name}");
            }
        }

        return sb.ToString().TrimEnd();

    }

    // Problem 10.
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var sb = new StringBuilder();


        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle
                            })
                            .ToArray()
            })
            .ToArray();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} – {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();

    }

    // Problem 11.
    public static string GetLatestProjects(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(d => new
            {
                d.Name,
                d.Description,
               StartDate =  d.StartDate.ToString("M/d/yyyy h:mm:ss tt")
            })
            .OrderBy(d => d.Name)
            .ToArray();

        foreach (var p in projects)
        {
            sb.AppendLine($"{p.Name}")
              .AppendLine($"{p.Description}")
              .AppendLine($"{p.StartDate}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 12.
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" || 
                        e.Department.Name == "Marketing" || 
                        e.Department.Name == "Information Services")
            .ToArray();

        foreach (var e in employees)
        {
            e.Salary *= 1.12m;
        }

        context.SaveChanges();

        var outputEmployees = employees
               .OrderBy(e => e.FirstName)
               .ThenBy(e => e.LastName)
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   NewSalary = e.Salary
               })
               .ToArray();

        foreach (var e in outputEmployees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.NewSalary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 13.
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var sb = new StringBuilder();


        var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .ToArray();

        var outputEmployees = employees
               .OrderBy(e => e.FirstName)
               .ThenBy(e => e.LastName)
               .Select(e => new
               {
                   e.FirstName,
                   e.LastName,
                   e.JobTitle,
                   e.Salary
               });

        foreach (var e in outputEmployees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }
}