using System;
using System.Collections.Generic;

namespace GalaxySearch
{
    public class Star
    {
        public String Name { get; set; }
        public Char Class { get; set; }
        public Int32 Temperatur { get; set; }
        public Decimal Luminosity { get; set; }
        public Decimal Mass { get; set; }
        public Decimal Size { get; set; }

        public List<Planet> Planets = new List<Planet>();

        public void SetClass()
        {
            if (this.Temperatur >= 30000)
            {
                this.Class = 'O';
            }
            else if (this.Temperatur > 10000 && this.Temperatur < 30000)
            {
                this.Class = 'B';
            }
            else if (this.Temperatur > 7500 && this.Temperatur <= 10000)
            {
                this.Class = 'A';
            }
            else if (this.Temperatur > 6000 && this.Temperatur <= 7500)
            {
                this.Class = 'F';
            }
            else if (this.Temperatur > 5200 && this.Temperatur <= 6000)
            {
                this.Class = 'G';
            }
            else if (this.Temperatur > 3700 && this.Temperatur <= 5200)
            {
                this.Class = 'K';
            }
            else if (this.Temperatur >= 2400 && this.Temperatur <= 3700)
            {
                this.Class = 'M';
            }
        }
    }
}