using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Models
{
    public class Moon
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string EnglishName { get; set; } = string.Empty;

        public string? PlanetId { get; set; }

        public double? MassValue { get; set; }

        public int? MassExponent { get; set; }

        public double Gravity { get; set; }

        public int? AvgTemp { get; set; }
    }
}
