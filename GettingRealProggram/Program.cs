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

            Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(false);
                
                switch (cki.KeyChar.ToString()) {
                    case "1":
                        userFunctions.RegisterUser();
                        break;

                    case "2":
                        userFunctions.DoesUserExist();
                        break;

                    default:
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("Forkert input");
                        Console.WriteLine();
                        Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
                        break;
                }
                
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
