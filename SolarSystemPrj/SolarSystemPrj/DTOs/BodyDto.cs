using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.DTOs
{
    using System.Text.Json.Serialization;

    namespace SolarSystemPrj.DTOs
    {
        public class BodyDto
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } 

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("englishName")]
            public string EnglishName { get; set; }

            [JsonPropertyName("isPlanet")]
            public bool IsPlanet { get; set; }

            [JsonPropertyName("bodyType")]
            public string BodyType { get; set; }

            [JsonPropertyName("semimajorAxis")]
            public double SemiMajorAxis { get; set; }

            [JsonPropertyName("gravity")]
            public double Gravity { get; set; }

            [JsonPropertyName("avgTemp")]
            public int? AvgTemp { get; set; }

            [JsonPropertyName("mass")]
            public MassDto? Mass { get; set; }

            [JsonPropertyName("aroundPlanet")]
            public AroundPlanetDto? AroundPlanet { get; set; }

            [JsonPropertyName("moons")]
            public List<MoonReferenceDto>? Moons { get; set; }
        }
    }
}
