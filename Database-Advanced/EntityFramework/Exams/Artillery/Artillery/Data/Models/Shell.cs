using Artillery.Common;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        public double ShellWeight { get; set; }

        [MaxLength(GlobalConstants.CaliberMax)]
        public string Caliber { get; set; } = null!;
        public ICollection<Gun> Guns { get; set; }
    }
}
