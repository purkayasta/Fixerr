using System.Text.Json.Serialization;

namespace FixSharp.Models
{
    /// <summary>
    /// Error Response model in return type
    /// </summary>
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public ErrorInfo ErrorInfo { get; set; }
    }

    public class ErrorInfo
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
