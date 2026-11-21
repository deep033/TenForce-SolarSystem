using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Models
{
    public class Planet
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string EnglishName { get; set; } = string.Empty;

        public double SemiMajorAxis { get; set; }

        public List<Moon> Moons { get; set; } = new();
    }
}
