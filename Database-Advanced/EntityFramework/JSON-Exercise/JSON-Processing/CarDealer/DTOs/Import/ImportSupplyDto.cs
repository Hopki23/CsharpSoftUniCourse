using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportSupplyDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("isImporter")]
        public bool IsImported { get; set; }
    }
}
