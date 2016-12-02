using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal {
    public class Menu {
        public UserFunctions userFunctions;
        public static List<Haircutter> haircutters;

        public void Init() {
            //temp
            haircutters = new List<Haircutter>();
            Haircutter haircutter = new Haircutter("Louise");
            haircutters.Add(haircutter);
            
            userFunctions = new UserFunctions();
            userFunctions.Init();
        }

        public void MainMenu() {
            Console.WriteLine("MENU:");
            Console.WriteLine("tryk '1' hvis du er en kunde");
            Console.WriteLine("tryk '2' hvis du er frisør");
            ConsoleKeyInfo cki;
            do {
                cki = Console.ReadKey(false);
                switch (cki.KeyChar.ToString()) {
                    case "1":
                        UserMenu();
                        MainMenu();
                        break;

                    case "2":
                        Console.Clear();
                        HaircutterMenu();
                        MainMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("MENU:");
                        Console.WriteLine("tryk '1' for kunde");
                        Console.WriteLine("tryk '2' for frisør");
                        Console.WriteLine("Forkert input");
                        userFunctions.DatabaseUpdate();
                        Console.WriteLine();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            userFunctions.DatabaseUpdate();
            Environment.Exit(1);
        }
        public void UserMenu(Customer tempcurrentcustomer = null) {
            ConsoleKeyInfo cki;
            Customer currentCustomer;
            currentCustomer = tempcurrentcustomer;
            if (currentCustomer == null) {
                currentCustomer = userFunctions.DoesUserExist();
                Console.Clear();
            }
            if (currentCustomer == null) {
                MainMenu();
            }

            Console.WriteLine("Du er logget på som: " + currentCustomer.Name + ' ' + currentCustomer.LastName);
            Console.WriteLine("Tryk '1' hvis du ønsker at oprette en ny tid");
            Console.WriteLine("Tryk '2' hvis du ønsker at se liste over dine tider");
            Console.WriteLine("Tryk '3' hvis du ønsker at logge på som en anden");
            Console.WriteLine("Tryk '4' hvis du ønsker at logge ud og vende tilbage til hovedmenu'en");
            cki = Console.ReadKey(false);
            switch (cki.KeyChar.ToString()) {
                case "1":
                    Console.Clear();
                    userFunctions.ChooseDate(currentCustomer);
                    UserMenu(currentCustomer);
                    break;

                case "2":
                    Console.Clear();
                    userFunctions.ShowTimes(currentCustomer);
                    UserMenu(currentCustomer);
                    break;

                case "3":
                    Console.Clear();
                    UserMenu();
                    break;

                case "4":
                    Console.Clear();
                    MainMenu();
                    break;

                default:
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Forkert input");
                    Console.WriteLine();
                    MainMenu();
                    break;
            }
        }
        public void HaircutterMenu() {
            ConsoleKeyInfo cki;
            Console.WriteLine("Du er logget på som: Frisør");
            Console.WriteLine("Tryk '1' hvis du ønsker at se liste over kunder");
            Console.WriteLine("Tryk '2' hvis du ønsker at se næste kunde og deres tid");
            Console.WriteLine("Tryk '3' hvis du ønsker at logge på som en anden (TBD)");
            Console.WriteLine("Tryk '4' hvis du ønsker at logge ud og vende tilbage til hovedmenu'en");
            cki = Console.ReadKey(false);
            switch (cki.KeyChar.ToString()) {
                case "1":
                    Console.Clear();
                    userFunctions.ListCustomers();
                    HaircutterMenu();
                    break;
                case "2":
                    Console.Clear();
                    //asuming signed in as Louise
                    DateTime nextTime = haircutters.Find(x => x.Name == "Louise").NextTime();
                    Customer foundCustomer = userFunctions.FindCustomerByTime(nextTime, "Louise");
                    userFunctions.PrintCustomer(foundCustomer);
                    Console.WriteLine();
                    HaircutterMenu();
                    break;

                case "4":
                    Console.Clear();
                    MainMenu();
                    break;

                default:
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Forkert input");
                    Console.WriteLine();
                    HaircutterMenu();
                    break;
            }        
        }
    }
}