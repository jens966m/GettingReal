using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal
{
    public class Customer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        //public List<Time> Times = new List<Time>();
        public List<DateTime> Times = new List<DateTime>();

        public Customer(int Phone)
        {
            this.Phone = Phone;
        }

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, int phone)
        {
            Name = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public Customer(string firstName, string lastName, int phone, List<DateTime> times) : this(firstName, lastName, phone)
        {
            Times = times;
        }

        public void BookATime(string day, string month, string year, string hour, string minute, string second)
        {
            //Times.Add(new Time() { Day = day, Month = month, Year = year, Hour = hour, Minuttes = minuttes });
            Times.Add(new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second)));
        }
    }
}