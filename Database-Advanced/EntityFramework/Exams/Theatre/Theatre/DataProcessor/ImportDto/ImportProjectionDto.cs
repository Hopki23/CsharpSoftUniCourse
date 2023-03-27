using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportProjectionDto
    {
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; } = null!;
        public ImportTicketDto[] Tickets { get; set; }
    }
}
