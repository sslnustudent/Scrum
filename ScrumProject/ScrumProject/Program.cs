using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuchoice;
            while (true)
            {
                menuchoice = MenuChoice();
                switch (menuchoice)
                {
                    case 0:
                        return;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }
        }

        static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n  Tryck valfri tangent för att fortsätta   ");
            Console.ResetColor();
            Console.ReadKey();
        }

        static int MenuChoice()
        {
            int menuChoice = -1;

            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("============================================");
                    Console.WriteLine("                 Register                   ");
                    Console.WriteLine("============================================\n");
                    Console.ResetColor();
                    Console.WriteLine("0. Avsluta.");
                    Console.WriteLine("1. Skapa ny medlem");
                    Console.WriteLine("2. Få lista med medlemar");
                    Console.WriteLine("3. Ändra information om medlem");
                    Console.WriteLine("4. Radera medlem");
                    Console.WriteLine("5. Se medlems info");
                    Console.WriteLine("============================================\n");

                    Console.Write("Ange menyval [0-5]: ");

                    menuChoice = int.Parse(Console.ReadLine());

                    if (menuChoice >= 0 && menuChoice <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("***FELL*** Ange nummer mellan 0-5!!!");
                        ContinueOnKeyPressed();
                    }
                }
                
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\nFEL!!! Kunde inte tolkas som en siffra");
                Console.ResetColor();
                ContinueOnKeyPressed();
            }
            return menuChoice;
        }
    }
}
