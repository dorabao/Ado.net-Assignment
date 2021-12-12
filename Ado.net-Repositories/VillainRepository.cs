using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.net_Entities;
using Dapper;

namespace Ado.net_Repositories
{
    public class VillainRepository : IRepositories<Villain>
    {
        MinionsDBContext _db;
        public VillainRepository()
        { 
            _db = new MinionsDBContext();

        }

        public int Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("Delete from Villain where VillainId = @VillainId", new { VillainId = id});
            }
        }

        public Villain Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.QueryFirstOrDefault<Villain>("Select VillainId, VillainName, Villain EvilnessFactorId from Villain Where id = @VillainId", new { VillainId = id});
            }
        }
        public int GetMaxID()
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("SELECT MAX(VillainId) AS VillainID FROM Villain");
                if (result != null && Enumerable.Count(result) == 1)
                {
                    return Enumerable.First(result).Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int IsVillainExist(string name)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("select v.VillainId from Villain v where v.VillainName = @VillainName", new {VillainName = name});
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


        public string IsVillainExist(int id)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("select v.VillainName from Villain v where v.VillainId = @VillainId", new { VillainId =id });
                if (result != null && Enumerable.Count(result) == 1)
                {
                    return Enumerable.First(result).Value;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Villain> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Query<Villain>("Select VillainId, VillainName, Villain EvilnessFactorId from Villain");
            }
        }

        public int Insert(Villain entity)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("insert into Villain values(@VillainId, @VillainName, @EvilnessFactorId)", entity);
            }
        }

        public int Update(Villain entity)
        {
            throw new NotImplementedException();
        }
    }
}