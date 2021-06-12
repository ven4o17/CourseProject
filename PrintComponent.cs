using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxySearch
{
    public class PrintComponent
    {
        public List<Galaxy> Galaxies { get; private set; }

        public PrintComponent(List<Galaxy> galaxies)
        {
            this.Galaxies = galaxies;
        }

        public String PrintStar(Star star)
        {
            var info = new StringBuilder();
            info.AppendLine($"    -   Name: {star.Name}");
            info.AppendLine($"        Class: {star.Class} ({star.Mass}, {star.Size}, {star.Temperatur}, {star.Luminosity})");
            info.AppendLine($"        Plantes:");
            foreach (var planet in star.Planets)
            {
                info.Append(this.PrintPlanet(planet));
            }

            return info.ToString();
        }

        private String PrintPlanet(Planet planet)
        {
            var info = new StringBuilder();
            var supportLife = planet.IsLifeSupported ? "yes" : "no";
            info.AppendLine($"           \u25CB   Name: {planet.Name}");
            info.AppendLine($"               Type: {planet.ConvertPlanetTypeEnumToString()}");
            info.AppendLine($"               Support life: {supportLife}");
            info.AppendLine($"               Moons:");
            foreach (var moon in planet.Moons)
            {
                info.AppendLine($"                  \u25A0   {moon.Name}");
            }
            return info.ToString();
        }
    }
}