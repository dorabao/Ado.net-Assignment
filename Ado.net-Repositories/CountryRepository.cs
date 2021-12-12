using Ado.net_Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Repositories
{
    public class CountryRepository : IRepositories<Country>
    {
        MinionsDBContext _db;
        public CountryRepository()
        {
            _db = new MinionsDBContext();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Country entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public int IsCountryExist(string name)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("select c.CountryId from Country c where c.CountryName = @CountryName", new { CountryName = name });
                if (result != null && Enumerable.Count(result) == 1)
                {
                    return Enumerable.First(result).Value;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
