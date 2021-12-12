using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Repositories
{
    public interface IRepositories<TEntity> where TEntity : class
    {
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);

        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);

    }
}
