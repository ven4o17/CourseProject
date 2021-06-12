using System;
using System.Collections.Generic;

namespace GalaxySearch
{
    public class Planet
    {
        public String Name { get; set; }
        public PlanetType Type { get; set; }
        public Boolean IsLifeSupported { get; set; }


        public List<Moon> Moons = new List<Moon>();

        public String ConvertPlanetTypeEnumToString()
        {
            if (this.Type == PlanetType.Terrestrial)
            {
                return "terrestrial";
            }
            else if (this.Type == PlanetType.GiantPlanet)
            {
                return "giant planet";
            }
            else if (this.Type == PlanetType.IceGiant)
            {
                return "ice giant";
            }
            else if (this.Type == PlanetType.Mesoplanet)
            {
                return "mesoplanet";
            }
            else if (this.Type == PlanetType.MiniNeptun)
            {
                return "mini-neptun";
            }
            else if (this.Type == PlanetType.Planetar)
            {
                return "planetar";
            }
            else if (this.Type == PlanetType.SuperEarth)
            {
                return "super-earth";
            }
            else if (this.Type == PlanetType.SuperJupiter)
            {
                return "super-jupiter";
            }

            return "sub-earth";
        }
    }
}
