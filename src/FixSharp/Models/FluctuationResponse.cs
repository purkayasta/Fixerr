using System.Text.Json.Serialization;

namespace Fixerr.Models
{
    public class FluctuationResponse : BaseResponse
    {
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, FluctuationRateInfo> Rates { get; set; }
    }

    public class FluctuationRateInfo
    {
        [JsonPropertyName("start_rate")]
        public double StartRate { get; set; }

        [JsonPropertyName("end_rate")]
        public double EndRate { get; set; }

        [JsonPropertyName("change")]
        public double Change { get; set; }

        [JsonPropertyName("change_pct")]
        public double ChangePercentage { get; set; }
    }
}
