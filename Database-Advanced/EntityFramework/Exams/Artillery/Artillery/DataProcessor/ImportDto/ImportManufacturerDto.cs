using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [MinLength(GlobalConstants.ManufacturerNameMin)]
        [MaxLength(GlobalConstants.ManufacturerNameMax)]
        public string ManufacturerName { get; set; } = null!;

        [XmlElement("Founded")]
        [MinLength(GlobalConstants.FoundedMin)]
        [MaxLength(GlobalConstants.FoundedMax)]
        public string Founded { get; set; } = null!;
    }
}
