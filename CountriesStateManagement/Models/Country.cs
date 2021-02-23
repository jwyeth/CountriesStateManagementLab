using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesStateManagement.Models
{
    public class Country
    {
        public string Name { get; set; }
        public List<string> OfficialLanguage { get; set; } = new List<string>();
        public string Greeting { get; set; }
        public List<string> Colors { get; set; } = new List<string>();
        public string Description { get; set; }


        public Country()
        {

        }

        public Country(string Name, List<string> OfficialLanguages, string Greeting, List<string> Colors, string Description)
        {
            this.Name = Name;
            this.OfficialLanguage = OfficialLanguages;
            this.Greeting = Greeting;
            this.Colors = Colors;
            this.Description = Description;
        }
    }
}
