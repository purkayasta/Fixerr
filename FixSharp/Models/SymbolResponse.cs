using System.Text.Json.Serialization;

namespace FixSharp.Models
{
    public class SymbolResponse : BaseResponse
    {
        [JsonPropertyName("symbols")]
        public Dictionary<string, string> Symbols { get; set; }
    }
}
