using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Entities
{
    public class MinionVillain
    {
        public int MinionId { get; set; }
        public int VillainId { get; set; }

        public Minion minion { get; set; }
        public Villain villain { get; set; }
    }
}
