using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SolarSystemPrj.DTOs
{
    public class SolarSystemResponseDto
    {
        [JsonPropertyName("bodies")]
        public List<BodyDto> Bodies { get; set; } = new List<BodyDto>();
    }
}
