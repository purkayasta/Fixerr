using System.Text.Json.Serialization;

namespace FixSharp.Models
{
    public class HistoricRateResponse : BaseResponse
    {
        [JsonPropertyName("historical")]
        public bool Historical { get; set; }

        [JsonPropertyName("date")]
        public DateOnly Date { get; set; }

        [JsonPropertyName("timestamp")]
        public int TimeStamp { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, string> Rates { get; set; }
    }
}
