using System;
using System.Collections.Generic;
using System.Linq;
using GettingReal;

namespace GettingRealProggram {
    public class UserFunctions
    { 
        public List<Customer> customers;
        Customer customer = new Customer();
        
        public void Init() {
                customers = new List<Customer>();
        }

        public void RegisterUser()
        {
            Console.WriteLine();
            Console.WriteLine("Navn på bruger");
            do {
                customer.Name = Console.ReadLine();  
                Console.Clear();
                Console.WriteLine("Navn på bruger, må ikke indholde tal eller være blankt");
                if (customer.Name == "exit") {
                    Console.Clear();
                    Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
                    return;
                }
            } while (customer.Name == "" || customer.Name.Any(char.IsDigit));

            Console.Clear();
            Console.WriteLine("Bruger " + customer.Name + " oprettet");
            Console.WriteLine();
            Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
            customers.Add(customer);
           

        }

        public void DoesUserExist() {
            Customer currentCustomer = null;
            while (currentCustomer == null) {
                Console.WriteLine();
                Console.WriteLine("Indtast navn på din eksisterende bruger");
                string currentCustomerName = Console.ReadLine();

                if (currentCustomerName == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
                    return; 
                }

                currentCustomer = customers.Find(x => x.Name == currentCustomerName);
            }
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



            currentCustomer.BookATime(day, month, year, hour, minute);
            string timeString = currentCustomer.Times[0].ToString();

            Console.WriteLine("Du har booket en tid den:");
            Console.WriteLine(timeString);
            Console.WriteLine();
            Console.WriteLine("Tryk '1' for opret ny bruger eller tryk 2 for booking af tid");
        }
    }
}