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
    public class MinionRepository : IRepositories<Minion>
    {
        MinionsDBContext _db;

        public MinionRepository()
        {
            _db = new MinionsDBContext();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Minion Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.QueryFirstOrDefault<Minion>("select MinionId, MinionName, Age, TownId from Minion where MinionId = @MinionId", new { MinionId = id });
            }
        }

        public int IsMinionExist(string name)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic result = conn.QueryFirstOrDefault("select m.MinionId from Minion m where m.MinionName = @MinionName", new {MinionName = name});
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


        public IEnumerable<Minion> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Query<Minion>("Select MinionId, MinionName, Age, TownId from Minion");
            }
        }

        public int Insert(Minion entity)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("insert into Minion values(@MinionName, @Age, @TownId)", entity);
            }
        }

        public int Update(Minion entity)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("update Minion set MinionName = @MinionName, Age = @Age, TownId = @TownId where MinionId = @MinionId", entity);
            }
        }

        public int IncreaseAge(int mID)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("EXEC usp_GetOlder @MID", new { MID = mID});
            }
        }

    }
}
