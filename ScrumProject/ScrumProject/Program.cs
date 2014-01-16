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
           /* members.Add(new Member()
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
            });*/
            int id = 1;
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
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine(" ***Det finns inga registrerade medlemar*** ");
                            Console.WriteLine("============================================");
                            Console.ResetColor();
                            ContinueOnKeyPressed();
                        }
                        else
                        {
                            MemberList(members);
                        }
                        break;
                    case 3:
                        if (members.Count == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine(" ***Det finns inga registrerade medlemar*** ");
                            Console.WriteLine("============================================");
                            Console.ResetColor();
                            ContinueOnKeyPressed();
                        }
                        else
                        {
                            EditMember(members);
                        }
                        break;
                    case 4:
                        if (members.Count == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine(" ***Det finns inga registrerade medlemar*** ");
                            Console.WriteLine("============================================");
                            Console.ResetColor();
                            ContinueOnKeyPressed();
                        }
                        else
                        {
                            RemoveMember(members);
                        }
                        break;
                    case 5:
                        if (members.Count == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine(" ***Det finns inga registrerade medlemar*** ");
                            Console.WriteLine("============================================");
                            Console.ResetColor();
                            ContinueOnKeyPressed();
                        }
                        else
                        {
                            MemberInfo(members);
                        }
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
            Console.Clear();
            while (true)
            {
                Console.Write("Ange förnamn: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("DU ANGAV INGET!!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
            while (true)
            {
                Console.Write("Ange efternamn: ");
                surname = Console.ReadLine();
                if (surname == "")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("DU ANGAV INGET!!!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
            while(true)
            {
                try
                {
                    Console.Write("Ange telefonnummer: ");
                    number = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Du ANGAV INGET TELEFON-NUMMER!!!\n");
                    Console.ResetColor();
                }

            }
            members.Add(new Member()
            {
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

        static void EditMember(List<Member> members)
        {
            while (true)
            {
                int id;
                int menuchoice;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("============================================");
                Console.WriteLine("           Lista över medlemar              ");
                Console.WriteLine("============================================\n");
                Console.ResetColor();
                Console.WriteLine("0.   Avsluta");
                for (int i = 0; i < members.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".   " + members[i].Name + " " + members[i].Surname);
                }
                Console.Write("\nVälj alternativ: ");
                try
                {
                    menuchoice = int.Parse(Console.ReadLine());
                    if (menuchoice < 0 || menuchoice > members.Count)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("      ***Ange ett antal mellan 0-{0}***     ", members.Count);
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                    }
                    else if (menuchoice == 0)
                    {
                        break;
                    }
                    else
                    {
                        id = menuchoice;
                        ConsoleKeyInfo key;
                        string newValue;
                        while (true)
                        {
                            try
                            {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine("          Information om medlem             ");
                            Console.WriteLine("============================================\n");
                            Console.ResetColor();
                            Console.WriteLine("0. Avsluta");
                            Console.WriteLine("1. Förnamn   : " + members[id - 1].Name);
                            Console.WriteLine("2. Efternamn : " + members[id - 1].Surname);
                            Console.WriteLine("3. Telefon   : " + members[menuchoice - 1].Number);
                            Console.Write("\nAnge vilken information du vill ändra :");
                            menuchoice = int.Parse(Console.ReadLine());
                            if (menuchoice < 0 || menuchoice > 3)
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("============================================");
                                Console.WriteLine("      ***Ange ett antal mellan 0-3***     ", members.Count);
                                Console.WriteLine("============================================");
                                Console.ResetColor();
                                ContinueOnKeyPressed();
                            }
                            else if (menuchoice == 0)
                            {
                                return;
                            }
                            else
                            {
                                switch (menuchoice)
                                {
                                    case 0:
                                        return;
                                    case 1:
                                        Console.Write("Ange Det nya förnamnet: ");
                                        newValue = Console.ReadLine();
                                        while (true)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine("Är du säker på att du vill byta {0} till {1} J/N", members[id - 1].Name, newValue);
                                            Console.ResetColor();

                                            key = Console.ReadKey();

                                            if (key.Key == ConsoleKey.J)
                                            {
                                                members[id].Name = newValue;
                                                Console.Clear();
                                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("============================================");
                                                Console.WriteLine("          Det nya namnet har satts          ");
                                                Console.WriteLine("============================================");
                                                Console.ResetColor();
                                                ContinueOnKeyPressed();
                                                return;
                                            }
                                            else if (key.Key == ConsoleKey.N)
                                            {
                                                break;
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
                                                ContinueOnKeyPressed();
                                            }

                                        }
                                        break;
                                    case 2:
                                        Console.Write("Ange Det nya efternamnet: ");
                                        newValue = Console.ReadLine();
                                        while (true)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine("Är du säker på att du vill byta {0} till {1} J/N", members[id - 1].Surname, newValue);
                                            Console.ResetColor();

                                            key = Console.ReadKey();

                                            if (key.Key == ConsoleKey.J)
                                            {
                                                members[id].Surname = newValue;
                                                Console.Clear();
                                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("============================================");
                                                Console.WriteLine("          Det nya namnet har satts          ");
                                                Console.WriteLine("============================================");
                                                Console.ResetColor();
                                                ContinueOnKeyPressed();
                                                return;
                                            }
                                            else if (key.Key == ConsoleKey.N)
                                            {
                                                break;
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
                                                ContinueOnKeyPressed();
                                            }

                                        }
                                        break;

                                    case 3:
                                        int newIntValue = 0;
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                Console.Write("Ange Det nya telefon-numret: ");
                                                newIntValue = int.Parse(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.Clear();
                                                Console.BackgroundColor = ConsoleColor.Red;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("============================================");
                                                Console.WriteLine("         ***FELL ANGE ETT NUMMER***         ");
                                                Console.WriteLine("============================================");
                                                Console.ResetColor();
                                                ContinueOnKeyPressed();
                                            }
                                        }
                                        while (true)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Yellow;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine("Är du säker på att du vill byta {0} till {1} J/N", members[id - 1].Number, newIntValue);
                                            Console.ResetColor();

                                            key = Console.ReadKey();

                                            if (key.Key == ConsoleKey.J)
                                            {
                                                members[id - 1].Number = newIntValue;
                                                Console.Clear();
                                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("============================================");
                                                Console.WriteLine("          Det nya nummret har satts         ");
                                                Console.WriteLine("============================================");
                                                Console.ResetColor();
                                                ContinueOnKeyPressed();
                                                return;
                                            }
                                            else if (key.Key == ConsoleKey.N)
                                            {
                                                break;
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
                                                ContinueOnKeyPressed();
                                            }

                                        }
                                        break;
                                }
                            }
                            }
                        catch
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("============================================");
                            Console.WriteLine("         ***FELL ANGE ETT NUMMER***         ");
                            Console.WriteLine("============================================");
                            Console.ResetColor();
                            ContinueOnKeyPressed();
                        }
                        }

                        break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("============================================");
                    Console.WriteLine("         ***FELL ANGE ETT NUMMER***         ");
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                }
            }
        }

        static void RemoveMember(List<Member> members)
        {

            while (true)
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
                Console.WriteLine("0.   Avsluta");
                for (int i = 0; i < members.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".   " + members[i].Name + " " + members[i].Surname);
                }
                Console.Write("\nVälj alternativ: ");
                try
                {
                    removeid = int.Parse(Console.ReadLine());
                    if (removeid < 0 || removeid > members.Count)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("      ***Ange ett antal mellan 0-{0}***     ", members.Count);
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                    }
                    else if (removeid == 0)
                    {
                        break;
                    }
                    else
                    {
                        while (true)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Är du säker på att du vill ta bort " + members[removeid - 1].Name + " " + members[removeid - 1].Surname + " J/N");
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
                                break;
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
                                ContinueOnKeyPressed();
                            }

                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("============================================");
                    Console.WriteLine("         ***FELL ANGE ETT NUMMER***         ");
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                }
            }
        }

        static void MemberInfo(List<Member> members)
        {
            while (true)
            {
                int menuchoice;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("============================================");
                Console.WriteLine("           Lista över medlemar              ");
                Console.WriteLine("============================================\n");
                Console.ResetColor();
                Console.WriteLine("0.   Avsluta");
                for (int i = 0; i < members.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".   " + members[i].Name + " " + members[i].Surname);
                }
                Console.Write("\nVälj alternativ: ");
                try
                {
                    menuchoice = int.Parse(Console.ReadLine());
                    if (menuchoice < 0 || menuchoice > members.Count)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("      ***Ange ett antal mellan 0-{0}***     ", members.Count);
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        ContinueOnKeyPressed();
                    }
                    else if (menuchoice == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Information om medlem             ");
                        Console.WriteLine("============================================\n");
                        Console.ResetColor();
                        Console.WriteLine("Förnamn   : " + members[menuchoice - 1].Name);
                        Console.WriteLine("Efternamn : " + members[menuchoice - 1].Surname);
                        Console.WriteLine("Telefon   : " + members[menuchoice - 1].Number);
                        Console.WriteLine("IDnummer  : " + members[menuchoice - 1].IdNumber);
                        ContinueOnKeyPressed();
                        break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("============================================");
                    Console.WriteLine("         ***FELL ANGE ETT NUMMER***         ");
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    ContinueOnKeyPressed();
                }
            }
        }
    }
}