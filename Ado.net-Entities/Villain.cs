using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_Entities
{
    public class Villain
    {
        public int VillainId { get; set; }
        public string VillainName { get; set; } = "";
        public int EvilnessFactorId { get; set; }

        public EvilnessFactor EvilnessFactor { get; set; }

        public Villain(int villainId, string villainName, int evilnessFacotor)
        {
            VillainId = villainId;
            VillainName = villainName;
            EvilnessFactorId = evilnessFacotor;
        }

        public Villain(int villainId, string villainName)
        {
            VillainId = villainId;
            VillainName = villainName;
            EvilnessFactorId = 7;
        }
    }
}
