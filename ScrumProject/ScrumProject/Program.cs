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
            List<Member> members = new List<Member>();
            members.Add(new Member()
            {
                Name = "Lars",
                Surname = "Sturesson",
                Number = 234354,
                IdNumber = 1
            });
            members.Add(new Member()
            {
                Name = "Philip",
                Surname = "Blad",
                Number = 234978,
                IdNumber = 2
            });
            members.Add(new Member()
            {
                Name = "Göran",
                Surname = "Kjellsson",
                Number = 8756456,
                IdNumber = 3
            });
            int id = 4;
            int menuchoice;
            while (true)
            {
                menuchoice = MenuChoice();
                switch (menuchoice)
                {
                    case 0:
                        return;
                    case 1:
                        AddMember(members, id);
                        id++;
                        break;
                    case 2:
                        if (members.Count == 0)
                        {
                            Console.WriteLine("Det finns inga registrerade medlemar");
                        }
                        else
                        {
                            MemberList(members);
                        }
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        if (members.Count == 0)
                        {
                            Console.WriteLine("Det finns inga registrerade medlemar");
                        }
                        else
                        {
                            RemoveMember(members);
                        }
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

        static void AddMember(List<Member> members, int id)
        {
            string name, surname;
            int number;
            Console.Write("Ange förnamn: ");
            name = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            surname = Console.ReadLine();
            Console.Write("Ange telefonnummer: ");
            number = int.Parse(Console.ReadLine());
            members.Add(new Member(){
                Name = name,
                Surname = surname,
                Number = number,
                IdNumber = id
            });
        }

        static void MemberList(List<Member> members)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================");
            Console.WriteLine("           Lista över medlemar              ");
            Console.WriteLine("============================================\n");
            Console.ResetColor();
            for (int i = 0; i < members.Count; i++ )
            {
                Console.WriteLine(members[i].Name + " " + members[i].Surname);
            }
            ContinueOnKeyPressed();
        }

        static void RemoveMember(List<Member> members)
        {
            ConsoleKeyInfo key;
            int removeid;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================");
            Console.WriteLine("           Lista över medlemar              ");
            Console.WriteLine("============================================\n");
            Console.ResetColor();
            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine(members[i].Name + " " + members[i].Surname + " ID: " + (i+1));
            }
            Console.Write("\nSkriv in IDet på medlemen du vill ta\nbort eller skriv 0 för att avbryta ");
            removeid = int.Parse(Console.ReadLine());
            if (removeid < 0 || removeid > (members.Count + 1))
            { 
            }
            else if (removeid == 0)
            {
            }
            else
            {
                while (true)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Är du säker på att du vill ta bort " + members[removeid - 1].Name + " " + members[removeid - 1].Surname);
                    Console.ResetColor();

                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.J)
                    {
                        members.RemoveAt(removeid - 1);
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Medlemen har tagits bort          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                        return;
                    }
                    else if (key.Key == ConsoleKey.N)
                    {

                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("  ***Ogilltig tangent tryck J eller N ***   ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                    }

                }
                
            }
        }
    }
}