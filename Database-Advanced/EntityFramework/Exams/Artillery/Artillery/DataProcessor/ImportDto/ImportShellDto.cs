using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellDto
    {
        [XmlElement("ShellWeight")]
        [Range(GlobalConstants.ShellWeightMin, GlobalConstants.ShellWeightMax)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [MinLength(GlobalConstants.CaliberMin)]
        [MaxLength(GlobalConstants.CaliberMax)]
        public string Caliber { get; set; } = null!;
    }
}