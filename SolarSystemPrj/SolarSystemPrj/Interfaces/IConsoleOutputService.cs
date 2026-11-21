using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Interfaces
{
    public interface IConsoleOutputService
    {
        void PrintAvgMoonGravity(List<Planet> planets);

        void PrintMoonMass(List<Moon> moons);

        void PrintPlanetsAndMoons(List<Planet> planets);

        void PrintAvgMoonTemp(List<Planet> planets);
    }
}
