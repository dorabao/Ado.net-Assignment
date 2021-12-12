using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Repositories
{
    public interface IMinionVillainRepository
    {
        dynamic GetMinionCountByVillain();

        dynamic GetMinionDetailByVillainId(int villainId);

        int AddMinionToVillain(int minionId, int villainId);
    }
}
