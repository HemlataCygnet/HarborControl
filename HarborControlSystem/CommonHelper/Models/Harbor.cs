using System.Collections.Generic;
using UI.Models;

namespace Helper.Models
{
    public class Harbor
    {
        public double WindSpeed { get; set; }
        public double City { get; set; }
        public double PerimeterLength { get; set; }
        public List<Boat> Boats { get; set; }
    }
}
