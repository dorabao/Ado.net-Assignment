using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.net_Entities;
using Ado.net_Repositories;

namespace Ado.net_Assignment.UI
{
    public class ManageVillain
    {
        VillainRepository repository;
        MinionVillainRepository repositorymv;
        public ManageVillain()
        {
            repository = new VillainRepository();
            repositorymv = new MinionVillainRepository();

        }

        public void VillainMinionCount()
        {
            dynamic d = repositorymv.GetMinionCountByVillain();
            foreach (dynamic item in d)
            {
                Console.WriteLine($"{item.VillainName} \t {item.NumberOfMinions}");
            }

        }

        public void VillainMinionDetail(int villainId)
        {
            dynamic d = repositorymv.GetMinionDetailByVillainId(villainId);

            if (Enumerable.Count(d) == 0)
            {
                Console.WriteLine($"No villain with ID {villainId} exisits in the database.");
            }
            else if (Enumerable.Count(d) == 1 && Enumerable.First(d).MinionId == null)
            {
                Console.WriteLine($"Vilain: {Enumerable.First(d).VillainName} \t (no minions)");
            }
            else
            {
                foreach (dynamic item in d)
                {
                    Console.WriteLine($"Vilain: {item.VillainName} \t {item.MinionId} \t {item.MinionName} \t {item.Age}");
                }
            }
        }

        public void ReleaseMinionOfVillain(int villainId)
        {
            string villainName = repository.IsVillainExist(villainId);
            if (villainName == null)
            {
                Console.WriteLine("No such Villain was found.");
            }
            else
            {
                int rows = repositorymv.Delete(villainId);
                repository.Delete(villainId);
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{rows} minions were released.");
            }
        }
    }
}
