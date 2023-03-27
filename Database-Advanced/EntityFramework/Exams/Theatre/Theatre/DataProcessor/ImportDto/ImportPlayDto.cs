using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [XmlElement("Duration")]
        public string Duration { get; set; } = null!;

        [XmlElement("Raiting")]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; } = null!;

        [XmlElement("Description")]
        [MaxLength(700)]
        public string Description { get; set; } = null!;

        [XmlElement("Screenwriter")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; } = null!;

    }
}