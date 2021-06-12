using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySearch
{
    public class SearchComponent
    {
        public List<Galaxy> Galaxies { get; private set; }

        public SearchComponent(List<Galaxy> galaxies)
        {
            this.Galaxies = galaxies;
        }

        public String GetGalaxies()
        {
            var galaxies = new StringBuilder();
            for (int i = 0; i < this.Galaxies.Count; i++)
            {
                galaxies.Append(this.Galaxies[i].Name);
                if (i != this.Galaxies.Count-1)
                {
                    galaxies.Append(',');
                }
            }

            return galaxies.ToString();
        }

        public String GetStars()
        {
            var result = new StringBuilder();
            var stars = this.Galaxies.SelectMany(g => g.Stars).ToList();
            for (int i = 0; i < stars.Count; i++)
            {
                result.Append(stars[i].Name);
                if (i != stars.Count - 1)
                {
                    result.Append(',');
                }
            }

            return result.ToString();
        }

        public String GetPlanets()
        {
            var result = new StringBuilder();
            var planets = this.Galaxies.SelectMany(g => g.Stars).SelectMany(s => s.Planets).ToList();
            for (int i = 0; i < planets.Count; i++)
            {
                result.Append(planets[i].Name);
                if (i != planets.Count - 1)
                {
                    result.Append(',');
                }
            }

            return result.ToString();
        }

        public String GetMoons()
        {
            var result = new StringBuilder();
            var moons = this.Galaxies.SelectMany(g => g.Stars).SelectMany(s => s.Planets).SelectMany(p => p.Moons).ToList();
            for (int i = 0; i < moons.Count; i++)
            {
                result.Append(moons[i].Name);
                if (i != moons.Count - 1)
                {
                    result.Append(',');
                }
            }

            return result.ToString();
        }
    }
}