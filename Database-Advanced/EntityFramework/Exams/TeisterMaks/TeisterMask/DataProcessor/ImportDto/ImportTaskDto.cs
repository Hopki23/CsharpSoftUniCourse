using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskDto
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
        [Required]
        public string DueDate { get; set; } = null!;

        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        public int LabelType { get; set; }  
    }
}