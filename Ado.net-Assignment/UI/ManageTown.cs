using Ado.net_Entities;
using Ado.net_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Assignment.UI
{
    public class ManageTown
    {
        TownRepository _repository;

        public ManageTown()
        {
            _repository = new TownRepository();
        }

        public void ChangeTownNameCasing(string countryName)
        {
            CountryRepository countryRepository = new CountryRepository();
            int count = 0;
            StringBuilder newNames = new StringBuilder();

            int countryId = countryRepository.IsCountryExist(countryName);
            if (countryId == -1)
            {
                Console.WriteLine("No town names were affected");
            }
            else {
                var towns = _repository.GetTownsByCountry(countryId);
                foreach (var town in towns)
                {
                    string newName = town.TownName.ToUpper();
                    Town newTown = new Town(town.TownId, newName, town.CountryId);
                    _repository.Update(newTown);
                    count++;
                    newNames.Append($"{newName}");
                }
                Console.WriteLine($"{count} town names were affected. [{newNames}]");
            }
        }
    }
}
