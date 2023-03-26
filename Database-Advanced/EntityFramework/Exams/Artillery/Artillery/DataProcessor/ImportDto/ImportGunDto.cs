using Artillery.Common;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunDto
    {
        public int ManufacturerId { get; set; }

        [Range(GlobalConstants.GunWeightMin, GlobalConstants.GunWeightMax)]
        public int GunWeight { get; set; }

        [Range(GlobalConstants.BarrelLengthMin, GlobalConstants.BarrelLengthMax)]
        public double BarrelLength { get; set; }
        public int? NumberBuild { get; set; }

        [Range(GlobalConstants.RangeMin, GlobalConstants.RangeMax)]
        public int Range { get; set; }
        public string GunType { get; set; } = null!;
        public int ShellId { get; set; }
        public ImportCountryGunDto[] Countries { get; set; }
    }
}
