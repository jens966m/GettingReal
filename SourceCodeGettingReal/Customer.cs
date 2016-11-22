using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal {
    public class Customer {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public List<Time> Times = new List<Time>();

        public Customer(int Phone) {
            this.Phone = Phone;
        }

        public Customer() {
        }

        public Customer(string firstName, string lastName, int phone) {
            Name = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public void BookATime(string day, string month, string year, string hour, string minuttes) {
            Times.Add(new Time() { Day = day, Month = month, Year = year, Hour = hour, Minuttes = minuttes });
        }
    }
}