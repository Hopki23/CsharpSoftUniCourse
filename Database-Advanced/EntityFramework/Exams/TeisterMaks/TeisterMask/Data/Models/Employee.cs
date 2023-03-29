using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeesTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Username { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(12)]
        public string Phone { get; set; } = null!;

        public ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
