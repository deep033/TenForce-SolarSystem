using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SolarSystemPrj.DTOs
{
    public class AroundPlanetDto
    {
        [JsonPropertyName("planet")]
        public string Planet { get; set; }

        [JsonPropertyName("rel")]
        public string Rel { get; set; }
    }
}
