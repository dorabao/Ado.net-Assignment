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
    public class MinionVillainRepository : IRepositories<MinionVillain>, IMinionVillainRepository
    {
        MinionsDBContext _db;
        public MinionVillainRepository()
        {
            _db = new MinionsDBContext();
        }

        public int AddMinionToVillain(int minionId, int villainId)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("insert into MinionVillain values(@MinionId, @VillainId)", new { MinionId = minionId, VillainId = villainId });
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                return conn.Execute("Delete from MinionVillain where VillainId = @VillainId", new { VillainId = id });
            }
        }

        public MinionVillain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MinionVillain> GetAll()
        {
            throw new NotImplementedException();
        }

        public dynamic GetMinionCountByVillain()
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic d = conn.Query(@"select v.VillainName, count(mv.MinionId) as NumberOfMinions
                from Villain v left join MinionVillain mv
                on v.VillainId = mv.VillainId
                group by v.VillainName
                having count(mv.MinionId) > 3
                order by v.VillainName desc");
                return d;
            }
        }

        public dynamic GetMinionDetailByVillainId(int villainId)
        {
            using (SqlConnection conn = new SqlConnection(_db.GetConnectionString()))
            {
                dynamic d = conn.Query(@"select v.VillainName, m.MinionId, m.MinionName, m.Age
                from MinionVillain mv inner join Minion m
                on mv.MinionId = m.MinionId
                right join Villain v
                on mv.VillainId = v.VillainId
                where v.VillainId = @villainId
                order by m.MinionName asc", new { VillainId = villainId });
                return d;
            }

        }

        public int Insert(MinionVillain entity)
        {
            throw new NotImplementedException();
        }

        public int Update(MinionVillain entity)
        {
            throw new NotImplementedException();
        }
    }
}
