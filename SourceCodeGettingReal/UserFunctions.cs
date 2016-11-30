using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SourceCodeGettingReal {
    public class UserFunctions {
        public Menu menu = new Menu();
        private static string connectioString = "Server=ealdb1.eal.local; Database=ejl48_db; User Id=ejl48_usr; Password=Baz1nga48;";
        public List<Customer> customers;
        public int listStartLenght;
        Customer customer;


        public void Init() {
            customers = new List<Customer>();
            spGetAllCustomers();
            listStartLenght = customers.Count();

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
            } while (customer.Name == "" || customer.Name.Any(Char.IsDigit) || customer.Name.Contains(' '));

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

            } while (customer.LastName == "" || customer.LastName.Any(Char.IsDigit) || customer.LastName.Contains(' '));
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
        public Customer FindCustomerByTime(DateTime nextTime, string haircutter) {
            //missing haircutter specific!
            Customer result = customers.Find(x => x.Times.Contains(nextTime));
            return result;
        }

        public Customer DoesUserExist() {
            Customer currentCustomer = null;
            int phone;
            bool canConvert;
            string currentCustomerPhone = "";
            Console.Clear();
            Console.WriteLine("Indtast telefonnummer");

            while (currentCustomer == null) {
                currentCustomerPhone = Console.ReadLine();
                if (currentCustomerPhone == "exit") {
                    Console.Clear();
                    customer = null;
                    return customer;
                }

                canConvert = Int32.TryParse(currentCustomerPhone, out phone);
                if (currentCustomerPhone.Length == 8 && canConvert == true && !currentCustomerPhone.Contains(' ')) {
                    if (FindCustomerByPhone(phone) != null) {
                        currentCustomer = FindCustomerByPhone(phone);
                    } else {
                        Console.WriteLine();
                        Console.WriteLine("Systemet genkender ikke dette nummer, øsnker de at registrere dem?");
                        Console.WriteLine("'nej' hvis du skrev forkert og vil prøve igen");
                        Console.WriteLine("'ja' for at komme til registrering af ny bruger");

                        string newUser;
                        newUser = Console.ReadLine();
                        switch (newUser) {
                            case "ja":
                                RegisterUser(phone);
                                break;

                            case "nej":
                                return DoesUserExist();

                            case "exit":
                                customer = null;
                                Console.Clear();
                                return customer;

                            default:
                                Console.WriteLine("Skriv enten 'ja' eller 'nej'");
                                break;

                        }
                        currentCustomer = FindCustomerByPhone(phone);
                    }
                } else {
                    Console.Clear();
                    Console.WriteLine("Telefonnummer skal indeholde 8 tal og kun tal");
                }
            }
            return currentCustomer;
        }

        public void PrintCustomer(Customer foundCustomer) {
            Console.Clear();
            Console.WriteLine("Tid: " + foundCustomer.Times[0]);
            Console.WriteLine("Navn: " + foundCustomer.Name + " " + foundCustomer.LastName);
            Console.WriteLine("Tlf: " + foundCustomer.Phone);
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
            thisCustomer.BookATime(day, month, year, hour, minute, "00");

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
                Console.WriteLine(i + 1 + ": " + customers[i].Name + " " + customers[i].LastName + " - tlf: " + customers[i].Phone);
            }
            Console.WriteLine();
        }

        public void spGetAllCustomers() {
            using (SqlConnection con = new SqlConnection(connectioString)) {
                try {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("spGetAllCustomers", con);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd2.ExecuteReader();

                    List<DateTime> times = new List<DateTime>();

                    if (reader.HasRows) {
                        string firstName = null;
                        string lastName = null;
                        int phone = 0;
                        while (reader.Read()) {
                            firstName = reader["FirstName"].ToString().Trim();
                            lastName = reader["LastName"].ToString().Trim();
                            phone = Convert.ToInt32(reader["Phone"].ToString().Trim());
                        }
                        if (reader.NextResult()) {
                            while (reader.Read()) {
                                DateTime datevalue;
                                DateTime.TryParse(reader["BookingDateTime"].ToString(), out datevalue);
                                times.Add(datevalue);
                                menu.haircutters[0].Times.Add(datevalue);
                            }
                        }
                        
                        customers.Add(new Customer(firstName, lastName, phone, times));
                    }
                    con.Close();
                } catch (SqlException e) {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine();
                }
            }
        }

        public void DatabaseUpdate() {
            using (SqlConnection con = new SqlConnection(connectioString)) {
                try {
                    con.Open();

                    for (int i = listStartLenght; i < customers.Count; i++) {
                        SqlCommand cmd1 = new SqlCommand("spInsertCustomer", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add(new SqlParameter("FirstName", customers[i].Name));
                        cmd1.Parameters.Add(new SqlParameter("LastName", customers[i].LastName));
                        cmd1.Parameters.Add(new SqlParameter("Phone", customers[i].Phone));
                        if (customers[i].Times.Count > 0) {

                            cmd1.Parameters.Add(new SqlParameter("Booking", customers[i].Times[0]));
                        }
                        cmd1.ExecuteNonQuery();

                    }
                    con.Close();

                } catch (SqlException e) {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine();
                }
            }

        }
    }
}