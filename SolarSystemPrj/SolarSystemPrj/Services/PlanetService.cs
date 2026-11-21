using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using SolarSystemPrj.Interfaces;
using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Services
{
    public class PlanetService : IPlanetService
    {

        public List<Planet> GetPlanets(List<BodyDto> bodies, List<Moon> moons)
        {
            var planets = bodies.Where(w => w.IsPlanet).Select(x => new Planet
                {
                    Id = x.Id,
                    Name = x.Name,
                    EnglishName = x.EnglishName,
                    SemiMajorAxis = x.SemiMajorAxis,
                    Moons = moons.Where(m => m.PlanetId == x.Id).ToList()
                }).ToList();

            return planets;
        }


        public double? GetAvgMoonGravity(Planet planet)
        {
            if (planet.Moons.Count == 0)
                return null;

            return planet.Moons.Average(x => x.Gravity);
        }

        public double? GetAvgMoonTemp(Planet planet) 
        {
            if (planet.Moons.Count == 0)
                return null;

            return planet.Moons.Average(x => x.AvgTemp);
        }
    }
}
