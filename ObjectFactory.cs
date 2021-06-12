using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxySearch
{
    public class ObjectFactory
    {
        public List<Galaxy> Galaxies { get; private set; }

        public ObjectFactory(List<Galaxy> galaxies)
        {
            this.Galaxies = galaxies;
        }

        public void AddGalaxy(String name, String type, String age)
        {
            Enum.TryParse(type, out GalaxyType galaxyType);
            var galaxy = new Galaxy()
            {
                Name = name,
                Type = galaxyType,
                Age = age 
            };
            this.Galaxies.Add(galaxy);
        }

        public void AddStar(String galaxyName, String starName, Decimal mass, Decimal size, Int32 temp, Decimal luminosity)
        {
            var star = new Star()
            {
                Name = starName,
                Mass = mass,
                Size = size,
                Temperatur = temp,
                Luminosity = luminosity
            };
            star.SetClass();
            var galaxy = this.Galaxies.FirstOrDefault(g => g.Name == galaxyName);

            if (galaxy != null)
            {
                galaxy.Stars.Add(star);
            }
        }

        public void AddPlanet(String starName, String planetName, String type, Boolean isLifeSupported)
        {
            var planetType = this.ConvertPlanetTypeToEnum(type);
            if (planetType == PlanetType.None)
            {
                Console.WriteLine("Type of planet {0} doesnt exist in program.");
                return;
            }

            var planet = new Planet()
            {
                Name = planetName,
                Type = planetType,
                IsLifeSupported = isLifeSupported
            };

            var star = this.Galaxies.SelectMany(it => it.Stars).FirstOrDefault(s => s.Name == starName);

            if (star != null)
            {
                star.Planets.Add(planet);
            }
        }

        public void AddMoon(String planetName, String moonName)
        {
            var moon = new Moon() { Name = moonName };
            var planet = this.Galaxies.SelectMany(g => g.Stars).SelectMany(s => s.Planets).FirstOrDefault(p => p.Name == planetName);

            if (planet != null)
            {
                planet.Moons.Add(moon);
            }
        }

        public PlanetType ConvertPlanetTypeToEnum(String type)
        {
            if (type == "terrestrial")
            {
                return PlanetType.Terrestrial;
            }
            else if (type == "giant planet")
            {
                return PlanetType.GiantPlanet;
            }
            else if (type == "ice giant")
            {
                return PlanetType.IceGiant;
            }
            else if (type == "mesoplanet")
            {
                return PlanetType.Mesoplanet;
            }
            else if (type == "mini-neptunе")
            {
                return PlanetType.MiniNeptunе;
            }
            else if (type == "planetar")
            {
                return PlanetType.Planetar;
            }
            else if (type == "super-earth")
            {
                return PlanetType.SuperEarth;
            }
            else if (type == "super-jupiter")
            {
                return PlanetType.SuperJupiter;
            }
            else if (type == "sub-earth")
            {
                return PlanetType.SubEarth;
            }

            return PlanetType.None;
        }
    }
}
