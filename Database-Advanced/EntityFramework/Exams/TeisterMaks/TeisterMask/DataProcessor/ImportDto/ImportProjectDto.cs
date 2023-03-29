using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; } = null!;

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; } = null!;

        [XmlElement("DueDate")]
        public string? DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; }
    }
}
