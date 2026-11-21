using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Interfaces
{
    public interface IPlanetService
    {
        List<Planet> GetPlanets(List<BodyDto> bodies, List<Moon> moons);

        double? GetAvgMoonGravity(Planet planet);

        double? GetAvgMoonTemp(Planet planet);
    }
}
