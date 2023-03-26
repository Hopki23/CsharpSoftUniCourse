using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        [XmlElement("CountryName")]
        [MinLength(GlobalConstants.CountryNameMinLength)]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string CountryName { get; set; } = null!;

        [XmlElement("ArmySize")]
        [Range(GlobalConstants.ArmySizeMin, GlobalConstants.ArmySizeMax)]
        public int ArmySize { get; set; }
    }
}
