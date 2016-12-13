using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal {
    public class Hairdresser {
        public List<DateTime> Times = new List<DateTime>();
        public string Name;

        public Hairdresser(string name) {
            Name = name;
        }

        public DateTime NextTime() {
            Times.Sort();
            return Times[0];
        }
    }
}