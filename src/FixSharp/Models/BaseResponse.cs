// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Fixerr.Models
{
    /// <summary>
    /// Error Response model in return type
    /// </summary>
    /// 
    [Serializable]
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

    [Serializable]
    public class ErrorInfo
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
