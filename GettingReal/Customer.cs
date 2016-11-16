using System;
using System.Collections.Generic;

namespace GettingReal {
    public class Customer {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        public List<Time> Times = new List<Time>();

        public void BookATime(string day, string month, string year, string hour, string minuttes) {
            Times.Add(new Time() { Day = day, Month = month, Year = year, Hour = hour, Minuttes = minuttes });
        }

        public void ShowTimes() {
            Console.Clear();
            Console.WriteLine("List of times:");
            for (int i = 0; i < Times.Count; i++) {
                Console.WriteLine(i + 1 + ": " + Times[i].ToString());
            }
            Console.WriteLine();
        }
    }
}