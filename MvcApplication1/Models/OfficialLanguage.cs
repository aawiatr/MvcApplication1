using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class OfficialLanguage
    {
        public String Code { get; set; }
        public String Continent { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public int Population { get; set; }
        public int Percentage { get; set; }
        public double RoundedPercentage { get; set; }

    }
}