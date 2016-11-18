using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceCodeGettingReal {
    public class UserFunctions
    { 
        public List<Customer> customers;
        Customer customer;
        
        public void Init() {
                customers = new List<Customer>();
        }
        public void RegisterUser(int phone = 0) {
            Console.Clear();
            Console.WriteLine("Fornavn på bruger");
            customer = new Customer();
            do {
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
            /*
            if (phone == 0) {
                Console.Clear();
                Console.WriteLine("Telefonnummer på bruger");
                string tempPhoneString;
                int tempPhone = 0;
                bool canConvert;
                while (true) {
                    tempPhoneString = Console.ReadLine();
                    if (tempPhoneString == "exit") {
                        Console.Clear();
                        customer = null;
                        return;
                    }

                    Console.Clear();
                    Console.WriteLine("Telefonnummer skal indeholde 8 tal");
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
            } else {*/

            //call with phone number allready
            customer.Phone = phone;
                Console.Clear();
                Console.WriteLine("Bruger oprettet: ");
                Console.WriteLine("Navn: " + customer.Name + " " + customer.LastName + " - tlf: " + phone);
            //}
            customers.Add(customer);
        }

        public void ShowTimes(Customer currentCustomer) {
            Console.WriteLine("Liste af tider:");
            for (int i = 0; i < currentCustomer.Times.Count; i++) {
                Console.WriteLine(i + 1 + ": " + currentCustomer.Times[i].ToString());
            }
            Console.WriteLine();
        }

        public Customer FindCustomerByPhone(int searchedPhone) {
            Customer result = customers.Find(x => x.Phone == searchedPhone);
            return result;
        }


        public Customer DoesUserExist() {
            Customer currentCustomer = null;
            int phone;
            bool canConvert;
            Console.Clear();
            Console.WriteLine("Indtast telefonnummer");

            while (currentCustomer == null) {
                string currentCustomerPhone = Console.ReadLine();
                if (currentCustomerPhone == "exit") {
                    Console.Clear();
                    customer = null;
                    return customer;
                }
                
                canConvert = int.TryParse(currentCustomerPhone, out phone);
                if (currentCustomerPhone.Length == 8 && canConvert == true) {
                    if (FindCustomerByPhone(phone) != null) {
                        currentCustomer = FindCustomerByPhone(phone);
                    } else {
                        Console.WriteLine();
                        Console.WriteLine("Systemet genkender ikke dette nummer, øsnker de at regisrere dem?)");
                        Console.WriteLine("'nej' hvis du skrev forkert og vil prøve igen");
                        Console.WriteLine("'ja' for at komme til registrering af ny bruger");
                        ChooseIsNewUserMenu(phone);
                        currentCustomer = FindCustomerByPhone(phone);
                    }
                } else {
                    Console.Clear();
                    Console.WriteLine("Telefonnummer skal indeholde 8 tal og kun tal");
                }
            }
            return currentCustomer;
        }

        public void ChooseIsNewUserMenu(int phone) {

            string newUser;
            newUser = Console.ReadLine();
            switch (newUser) {
                case "ja":
                    RegisterUser(phone);
                    break;

                case "nej":
                    DoesUserExist();
                    break;

                default:
                    Console.WriteLine("Skriv enten 'ja' eller 'nej'");
                    ChooseIsNewUserMenu(phone);
                    break;

            }
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