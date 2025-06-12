using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class MainMenu
    {
        public static void Menu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║               MALSHINON MENU                 ║");
                Console.WriteLine("╠══════════════════════════════════════════════╣");
                Console.WriteLine("║  1. Create Report                            ║");
                Console.WriteLine("║  2. Admin Options                            ║");
                Console.WriteLine("║  0. Exit                                     ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Select an option (0-2): ");

                Console.ResetColor();


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Create report selected.");
                        ReportHandler.ReporterMenu();
                        break;
                    case "2":
                        Console.WriteLine("Admin options selected.");
                        AdminOptions.AdminMenu();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }

            }
        }

    }
}
