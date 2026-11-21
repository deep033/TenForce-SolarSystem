using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using SolarSystemPrj.Interfaces;
using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Services
{
    public class MoonService : IMoonService
    {
        public List<Moon> GetMoons(List<BodyDto> bodies)
        {
            var moons = bodies.Where(x => x.BodyType == "Moon").Select(s => new Moon
                {
                    Id = s.Id,
                    Name = s.Name,
                    EnglishName = s.EnglishName,
                    PlanetId = s.AroundPlanet?.Planet,
                    AvgTemp = s.AvgTemp,
                    MassValue = s.Mass?.MassValue,
                    MassExponent = s.Mass?.MassExponent,
                    Gravity = s.Gravity
                }).ToList();

            return moons;
        }
    }
}
