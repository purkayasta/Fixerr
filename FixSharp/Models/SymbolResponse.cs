using System.Text.Json.Serialization;

namespace FixSharp.Models
{
    public class SymbolResponse : ErrorResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
