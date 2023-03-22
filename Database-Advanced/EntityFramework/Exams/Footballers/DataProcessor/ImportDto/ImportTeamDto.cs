using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        //[JsonProperty("Name")]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Za-z0-9 .-]+$")]
        public string Name { get; set; } = null!;
        
        //[JsonProperty("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; } = null!;

        //[JsonProperty("Trophies")]
        public string Trophies { get; set; } = null!;

        //[JsonProperty("Footballers")]
        public int[] Footballers { get; set; }
    }
}

//"Name": "Brentford F.C.",
//    "Nationality": "The United Kingdom",
//    "Trophies": "5",
//    "Footballers": [
//      28,
//      28,
//      39,
//      57
//    ]