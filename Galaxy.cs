using System;
using System.Collections.Generic;

namespace GalaxySearch
{
    public class Galaxy
    {
        public String Name { get; set; }
        public GalaxyType Type { get; set; }
        public String Age { get; set; }

        public List<Star> Stars = new List<Star>();
    }
}
