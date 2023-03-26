using Artillery.Common;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        public string ManufacturerName { get; set; } = null!;

        [MaxLength(GlobalConstants.FoundedMax)]
        public string Founded { get; set; } = null!;
        public ICollection<Gun> Guns { get; set; }
    }
}