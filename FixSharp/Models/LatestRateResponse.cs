using System.Text.Json.Serialization;

namespace FixSharp.Models
{
    public class LatestRateResponse : ErrorResponse
    {
        /// <summary>
        /// Returns true or false depending on whether or not your API request has succeeded.\
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Returns the exact date and time (UNIX time stamp) the given rates were collected.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// Returns the three-letter currency code of the base currency used for this request.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public DateOnly Date { get; set; }

        /// <summary>
        /// Returns exchange rate data for the currencies you have requested.
        /// </summary>

        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
