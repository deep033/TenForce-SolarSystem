using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SolarSystemPrj.DTOs
{
    public class MassDto
    {
        [JsonPropertyName("massValue")]
        public double MassValue { get; set; }

        [JsonPropertyName("massExponent")]
        public int MassExponent { get; set; }
    }
}
