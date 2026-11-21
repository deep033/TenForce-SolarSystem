using SolarSystemPrj.Interfaces;
using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Services
{
    public class ConsoleOutputService : IConsoleOutputService
    {
        private readonly IPlanetService _planetService;

        public ConsoleOutputService(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        public void PrintAvgMoonGravity(List<Planet> planets)
        {
            Console.WriteLine("\nAverage gravity of moons per planet");
            Console.WriteLine("----------------------------------------");

            foreach (var planet in planets)
            {
                var avg = _planetService.GetAvgMoonGravity(planet);

                if (avg.HasValue)
                    Console.WriteLine($"{planet.Id}: {avg.Value}");
                else
                    Console.WriteLine($"{planet.Id}: 0");
            }
        }

        public void PrintMoonMass(List<Moon> moons)
        {
            Console.WriteLine("\nList of moons and their mass");
            Console.WriteLine("----------------------------------------");

            int count = 1;

            foreach (var moon in moons)
            {
                Console.WriteLine($"{count}. {moon.Id}");

                if (moon.MassValue.HasValue && moon.MassExponent.HasValue)
                {
                    Console.WriteLine($"Mass Value: {moon.MassValue}");
                    Console.WriteLine($"Mass Exponent: {moon.MassExponent}");
                }
                else
                {
                    Console.WriteLine("Mass not available");
                }

                count++;
            }
        }

        public void PrintPlanetsAndMoons(List<Planet> planets)
        {
            Console.WriteLine("\nList of planets and their moons");
            Console.WriteLine("----------------------------------------");

            int count = 1;

            foreach (var planet in planets)
            {
                Console.WriteLine($"\nPlanet {count}: {planet.Id}");
                Console.WriteLine($"Semi Major Axis: {planet.SemiMajorAxis}");
                Console.WriteLine($"Total Moons: {planet.Moons.Count}");

                int moonCount = 1;

                foreach (var moon in planet.Moons)
                {
                    Console.WriteLine($"{moonCount}. {moon.Id}");
                    moonCount++;
                }

                count++;
            }
        }

        public void PrintAvgMoonTemp(List<Planet> planets)
        {
            Console.WriteLine("\nAverage temperature of moons per planet");
            Console.WriteLine("----------------------------------------");

            foreach (var planet in planets)
            {
                if (planet.Moons.Count == 0)
                    continue;

                var avgTemp = _planetService.GetAvgMoonTemp(planet);

                if (avgTemp.HasValue)
                    Console.WriteLine($"{planet.Id}: {avgTemp.Value} K");
                else
                    Console.WriteLine($"{planet.Id}: -");
            }
        }
    }
}

