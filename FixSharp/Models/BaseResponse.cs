using System.Text.Json.Serialization;

namespace Fixerr.Models
{
    /// <summary>
    /// Error Response model in return type
    /// </summary>
    public class BaseResponse
    {
        // <summary>
        /// Returns true or false depending on whether or not your API request has succeeded.\
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

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
