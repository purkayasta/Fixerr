﻿using System.Text.Json.Serialization;

namespace Fixerr.Models
{
    public class TimeSeriesResponse : BaseResponse
    {
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, double>> Rates { get; set; }
    }
}
