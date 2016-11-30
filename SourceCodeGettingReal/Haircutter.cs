using System;
using System.Collections.Generic;

namespace SourceCodeGettingReal {
    public class Haircutter {
        public List<DateTime> Times = new List<DateTime>();
        public string Name;

        public Haircutter(string name) {
            Name = name;
        }

        public DateTime NextTime() {
            Times.Sort();
            return Times[0];
        }
    }
}