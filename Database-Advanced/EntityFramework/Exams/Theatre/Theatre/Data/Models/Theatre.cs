using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public sbyte NumberOfHalls { get; set; }

        [MaxLength(30)]
        public string Director { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; }
    }
}