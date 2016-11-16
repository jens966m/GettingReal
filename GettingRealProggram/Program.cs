using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GettingReal;

namespace GettingRealProggram {
    class Program
    {
        UserFunctions userFunctions;
        static void Main(string[] args) {
            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run()
        {
            userFunctions = new UserFunctions();
            userFunctions.Init();
            SwitchMenu();
        }
        public void SwitchMenu() {

            Console.WriteLine("MENU:");
            Console.WriteLine("Tryk '1' for opret ny bruger");
            Console.WriteLine("tryk '2' for booking af tid");
            Console.WriteLine("tryk '3' for list of customers");
            ConsoleKeyInfo cki;
            ConsoleKeyInfo cki2;
            do
            {
                cki = Console.ReadKey(false);

                switch (cki.KeyChar.ToString()) {
                    case "1":
                        userFunctions.RegisterUser();
                        SwitchMenu();
                        break;

                    case "2":
                        Customer currentCustomer = userFunctions.DoesUserExist();
                        Console.Clear();
                        Console.WriteLine("Hej " + currentCustomer.Name);
                        Console.WriteLine("Tryk '1' hvis du ønsker at oprette en ny tid");
                        Console.WriteLine("Tryk '2' hvis du ønsker at se liste over dine tider");
                        cki2 = Console.ReadKey(false);
                        switch (cki2.KeyChar.ToString()) {
                            case "1":
                                userFunctions.ChooseDate(currentCustomer);
                                break;
                            case "2":
                                currentCustomer.ShowTimes();
                                break;
                        }
                    
                        SwitchMenu();
                        break;

                    case "3":
                        userFunctions.ListCustomers();
                        SwitchMenu();
                        break;

                    default:
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("Forkert input");
                        Console.WriteLine();
                        SwitchMenu();
                        break;
                }
                
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
