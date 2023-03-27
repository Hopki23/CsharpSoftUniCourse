using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }
        
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public float Rating { get; set; }
        public Genre Genre { get; set; }
        [MaxLength(700)]
        public string Description { get; set; } = null!;

        [MaxLength(30)]
        public string Screenwriter { get; set; } = null!;
        public ICollection<Cast> Casts { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
