using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Entities
{
    public class Town
    {
        public int TownId { get; set; }
        public string TownName { get; set; } = "";
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public Town(int townId, string townName, int countryId)
        {
            TownId = townId;
            TownName = townName;
            CountryId = countryId;
        }

        public Town(string townName, int countryId)
        {
            TownName = townName;
            CountryId = countryId;
        }

        public Town(string townName)
        {
            TownName = townName;
            CountryId = 1;
        }

    }
}
