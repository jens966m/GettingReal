using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestGettingReal {
    public class UserFunctions
    { 
        public List<Customer> customers;
        Customer customer;
        
        public void Init() {
                customers = new List<Customer>();
        }
        public void RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("Fornavn på bruger");
            customer = new Customer();
            do {
                //if (Console.ReadKey(true).Key == ConsoleKey.Escape) {
                //    Console.Clear();
                //    customer = null;
                //    return;
                //}
                customer.Name = Console.ReadLine();  
                Console.Clear();
                Console.WriteLine("Fornavn på bruger, må ikke indholde tal eller være blankt");
                if (customer.Name == "exit") {
                    Console.Clear();
                    customer = null;
                    return;
                }
            } while (customer.Name == "" || customer.Name.Any(char.IsDigit));

            Console.Clear();
            Console.WriteLine("Efternavn på bruger");
            do {
                customer.LastName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Efternavn på bruger, må ikke indholde tal eller være blankt");
                if (customer.LastName == "exit") {
                    Console.Clear();
                    customer = null;
                    return;
                }

            } while (customer.LastName == "" || customer.LastName.Any(char.IsDigit));
            Console.Clear();
            Console.WriteLine("Telefonnummer på bruger");
            string tempPhoneString;
            int tempPhone = 0;
            bool canConvert;
            while(true) {
                tempPhoneString = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Telefonnummer skal indeholde 8 tal");
                if (tempPhoneString == "exit") {
                    Console.Clear();
                    customer = null;
                    return;
                }

                canConvert = int.TryParse(tempPhoneString, out tempPhone);
                if (tempPhoneString.Length == 8) {
                    if (canConvert == true) {
                        break;
                    }
                }
            }
            customer.Phone = tempPhone;

            Console.Clear();
            Console.WriteLine("Bruger oprettet: ");
            Console.WriteLine("Navn: " + customer.Name + " " + customer.LastName + " - tlf: " + customer.Phone);
            Console.WriteLine();
            customers.Add(customer);
        }

        public Customer DoesUserExist() {
            Customer currentCustomer = null;
            while (currentCustomer == null) {
                Console.Clear();
                Console.WriteLine("Indtast fornavn og efternavn på din eksisterende bruger");

                string currentCustomerName = Console.ReadLine();
                currentCustomer = customers.Find(x => x.Name + " " + x.LastName == currentCustomerName);
            }
            return currentCustomer;
        }

        public void ChooseDate(Customer thisCustomer) {
            Console.Clear();
            Console.WriteLine("Hvornår vil du klippes");
            Console.WriteLine("Hvilket år");
            string year = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Hvilken måned i tal");
            string month = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Hvilken dag i tal");
            string day = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Hvilken tid");
            string hour = Console.ReadLine();
            Console.Write(':');
            string minute = Console.ReadLine();
            Console.Clear();
            thisCustomer.BookATime(day, month, year, hour, minute);

            //show booked date
            int lastTime = thisCustomer.Times.Count() - 1;
            string timeString = thisCustomer.Times[lastTime].ToString();
            Console.WriteLine("Du har booket en tid den:");
            Console.WriteLine(timeString);
            Console.WriteLine();
        }

        public void ListCustomers() {
            Console.Clear();
            Console.WriteLine("List of cusomers:");
            for (int i = 0; i < customers.Count; i++) {
                Console.WriteLine(i+1 + ": " + customers[i].Name + " " + customers[i].LastName + " - tlf: " + customers[i].Phone);
            }
            Console.WriteLine();                  
        }
    }
}