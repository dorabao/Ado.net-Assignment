using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.net_Entities;
using Dapper;

namespace Ado.net_Repositories
{
    public class TownRepository : IRepositories<Town>
    {
        MinionsDBContext _db;

        public TownRepository()
        {
            _db = new MinionsDBContext();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Town Get(int id)
        {
            throw new NotImplementedException();
        }

        public int IsTownExist(string name)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("select t.TownId from Town t where t.TownName = @TownName", new { TownName = name});
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

        public IEnumerable<Town> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetTownsByCountry(int countryId)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Query<Town>("select TownId, TownName, CountryId from Town where CountryId = @countryId", new { countryId = countryId});
            }
        }
   

        public int Insert(Town entity)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("insert into Town values(@TownName, @CountryId)", entity);
            }

        }

        public int Update(Town entity)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("update Town set TownName = @TownName where TownId = @TownId", entity);
            }
        }
    }
}
