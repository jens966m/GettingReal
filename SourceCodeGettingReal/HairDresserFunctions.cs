using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeGettingReal {
    public class HairdresserFunctions {

        public void ListCustomers() {
            Console.Clear();
            Console.WriteLine("List of cusomers:");
            for (int i = 0; i < UserFunctions.customers.Count; i++) {
                Console.WriteLine(i + 1 + ": " + UserFunctions.customers[i].Name + " " + UserFunctions.customers[i].LastName + " - tlf: " + UserFunctions.customers[i].Phone);
            }
            Console.WriteLine();
        }

        public Customer FindCustomerByTime(DateTime nextTime, string hairdresser) {
            //missing hairdresser specific!
            Customer result = UserFunctions.customers.Find(x => x.Times.Contains(nextTime));
            return result;
        }

        public void PrintCustomer(Customer foundCustomer) {
            Console.Clear();
            Console.WriteLine("Tid: " + foundCustomer.Times[0]);
            Console.WriteLine("Navn: " + foundCustomer.Name + " " + foundCustomer.LastName);
            Console.WriteLine("Tlf: " + foundCustomer.Phone);
        }
        public List<AvailableTimes> getAvailableTimes() {
            return UserFunctions.availableDates;
        }

    }
}
