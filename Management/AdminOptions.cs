using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class AdminOptions
    {
        public static void AdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Admin Options ===");
                Console.WriteLine("1. shou all potential agents");
                Console.WriteLine("2. shou all dangerous targets");
                Console.WriteLine("3. shou all active alerts");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option (0-3): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        PersonDAL.GetPotentialAgents();
                        break;
                    case "2":
                        AlertDAL.GetDangers();
                        break;
                    case "3":
                        AlertDAL.GetActiveAlerts();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
