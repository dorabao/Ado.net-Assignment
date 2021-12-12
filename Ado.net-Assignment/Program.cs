using Ado.net_Assignment.UI;
using System;

namespace Ado.net_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageVillain manageVillain = new ManageVillain();
            ManageMinion manageMinion = new ManageMinion();
            ManageTown manageTown = new ManageTown();

            //Q2 Villian Names
            Console.WriteLine("Q2 Villian Names - Those are villains who has more than 3 minions:");
            manageVillain.VillainMinionCount();

            //Q3 Minion Names
            Console.WriteLine("Q3 Minion Names - Input a villain id:");
            int vid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Those are minions details of a given villian id:");
            manageVillain.VillainMinionDetail(vid);

            //Q4 Add Minion
            Console.WriteLine("Q4 Add Minion - Input Minion: <Name> <Age> <TownName>");
            string mname = Console.ReadLine();
            int mage = Convert.ToInt32(Console.ReadLine());
            string tname = Console.ReadLine();
            Console.WriteLine("Please input Villain: <Name>");
            string vname = Console.ReadLine();
            manageMinion.AddMinionToVillain(mname, mage, tname, vname);

            //Q5 Chnage Twon Names Casing
            Console.WriteLine("Q5 Chnage Twon Names Casing - Input a country name:");
            string country = Console.ReadLine();
            manageTown.ChangeTownNameCasing(country);

            //Q6 Remove Villain
            Console.WriteLine("Q6 Remove Villain - Input a villain's ID:");
            int vid2 = Convert.ToInt32(Console.ReadLine());
            manageVillain.ReleaseMinionOfVillain(vid2);

            //Q7 Print All Minion Names
            Console.WriteLine("Q7 Print All Minion Names - Print in a given order");
            manageMinion.PrintMinionsAlternately();

            //Q8 Increase Minion Age
            Console.WriteLine("Q8 Increase Minion Age - Input minions' IDs. Numbers separated by space.");
            string input = Console.ReadLine();
            string[] array = input.Split(' ');
            foreach (string s in array)
            {
                int mID2 = Convert.ToInt32(s);
                manageMinion.IncreaseAgeAndCapitalName(mID2);
            }
            manageMinion.PrintAllMinions();

            //Q9 Increase Age Stored Procedure
            Console.WriteLine("Q9 Increase Minion Age SP - Input minion's ID.");
            int mID = Convert.ToInt32(Console.ReadLine());
            manageMinion.IncreaseAgeBySP(mID);
        }
    }
}
