using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string Username { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [MaxLength(12)]
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; } = null!;

        public int[] Tasks { get; set; }
    }
}