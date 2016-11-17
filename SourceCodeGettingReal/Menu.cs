using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal {
    public class Menu {
        UserFunctions userFunctions;

        public void Init() {
            userFunctions = new UserFunctions();
            userFunctions.Init();
        }

        public void MainMenu() {
            Console.WriteLine("MENU:");
            Console.WriteLine("Tryk '1' for opret ny bruger");
            Console.WriteLine("tryk '2' for specifik bruger funktioner");
            Console.WriteLine("tryk '3' for liste over brugere (kun for frisør)");
            ConsoleKeyInfo cki;
            do {
                cki = Console.ReadKey(false);

                switch (cki.KeyChar.ToString()) {
                    case "1":
                    userFunctions.RegisterUser();
                    MainMenu();
                    break;

                    case "2":
                    UserMenu();
                    MainMenu();
                    break;

                    case "3":
                    userFunctions.ListCustomers();
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

            } while (cki.Key != ConsoleKey.Escape);
        }

        public void UserMenu() {
            ConsoleKeyInfo cki;
            Customer currentCustomer;
            currentCustomer = userFunctions.DoesUserExist();
            Console.Clear();
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
                    break;

                case "2":
                Console.Clear();
                userFunctions.ShowTimes(currentCustomer);
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
    }
}