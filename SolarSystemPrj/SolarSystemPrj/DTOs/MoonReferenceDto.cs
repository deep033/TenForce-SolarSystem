using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SolarSystemPrj.DTOs
{
    public class MoonReferenceDto
    {
        [JsonPropertyName("moon")]
        public string Moon { get; set; } = string.Empty;

        [JsonPropertyName("rel")]
        public string Rel { get; set; } = string.Empty;
    }
}
