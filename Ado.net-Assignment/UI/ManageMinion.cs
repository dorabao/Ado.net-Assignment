using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.net_Entities;
using Ado.net_Repositories;

namespace Ado.net_Assignment.UI
{
    public class ManageMinion
    {
        MinionRepository minionRepository;
        VillainRepository villainRepository;
        TownRepository townRepository;
        MinionVillainRepository minionVillainRepository;
        public ManageMinion()
        {
            minionRepository = new MinionRepository();
            villainRepository = new VillainRepository();
            townRepository = new TownRepository();
            minionVillainRepository = new MinionVillainRepository();
        }
        public void AddMinionToVillain(string minionName, int age, string townName, string villainName)
        {
            if (townRepository.IsTownExist(townName) == -1)
            {
                Town newTown = new Town(townName);
                townRepository.Insert(newTown);
                Console.WriteLine($"Town {townName} was added to the database.");
            }
            if (minionRepository.IsMinionExist(minionName) == -1)
            {
                int curTown = townRepository.IsTownExist(townName);
                Minion newMinion = new Minion(minionName, age, curTown);
                minionRepository.Insert(newMinion);
            }
            if (villainRepository.IsVillainExist(villainName) == -1)
            {
                int curLastId = villainRepository.GetMaxID();
                Villain villain = new Villain(curLastId + 1, villainName);
                villainRepository.Insert(villain);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            int curMinion = minionRepository.IsMinionExist(minionName);
            int curVillain = villainRepository.IsVillainExist(villainName);
            int result = minionVillainRepository.AddMinionToVillain(curMinion, curVillain);
            if (result >= 1)
            { 
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
            }
        }

        public void PrintMinionsAlternately()
        {
            var minions = minionRepository.GetAll();
            List<string> minionNames = new List<string>();

            foreach (var minion in minions)
            {
                minionNames.Add(minion.MinionName);

            }
            for (int i = 0, j = minionNames.Count() - 1; i <= j; i++, j--)
            {
                string first = minionNames[i];
                string last = minionNames[j];
                if (i == j) 
                {
                    Console.WriteLine(first);
                }
                else
                {
                    Console.WriteLine(first);
                    Console.WriteLine(last);
                }
            }
        }

        public void PrintAllMinions()
        {
            var minions = minionRepository.GetAll();
            if (minions != null)
            {
                foreach (var minion in minions)
                {
                    Console.WriteLine($"{minion.MinionName} {minion.Age}");
                }
            }
            else
            {
                Console.WriteLine("No minions in service");
            }
        }

        public void IncreaseAgeAndCapitalName(int minionId)
        {
            Minion targetMinion = minionRepository.Get(minionId);
            if (targetMinion != null)
            {
                int newAge = targetMinion.Age + 1;
                string newName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(targetMinion.MinionName);
                Minion updatedMinion = new Minion(targetMinion.MinionId, newName, newAge, targetMinion.TownId);
                minionRepository.Update(updatedMinion);
            }
        }

        public void IncreaseAgeBySP(int minionId)
        {
            minionRepository.IncreaseAge(minionId);
            var minion = minionRepository.Get(minionId);
            Console.WriteLine($"{minion.MinionName} {minion.Age}");
        }
    }
}
