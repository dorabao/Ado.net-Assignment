using System;

namespace Ado.net_Entities
{
    public class Minion
    {
        public int MinionId { get; set; }
        public string MinionName { get; set; } = "";
        public int Age { get; set; }
        public int TownId { get; set; }

        public Town Town { get; set; }

        public Minion(int minionId, string minionName, int age, int townId)
        {
            MinionId = minionId;
            MinionName = minionName;
            Age = age;
            TownId = townId;
        }

        public Minion(string minionName, int age, int townId)
        {
            MinionName = minionName;
            Age = age;
            TownId = townId;
        }

        public Minion(int minionId, string minionName)
        {
            MinionId = minionId;
            MinionName = minionName;
        }
    }
}
