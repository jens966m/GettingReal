using System;
using System.Security.Cryptography.X509Certificates;

namespace SourceCodeGettingReal {
    public class Time {
        internal string Day;
        internal string Month;
        internal string Hour;
        internal string Year;
        internal string Minuttes;
        internal string Second = "00";
        public DateTime dateTime;

        public DateTime NewDatetime() {
            dateTime = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day), Convert.ToInt32(Hour), Convert.ToInt32(Minuttes), Convert.ToInt32(Second));
            return dateTime;
        }

        public override string ToString()
        {
            string res = Year + '-' + Month + '-' + Day + ' ' + Hour + ':' + Minuttes + ":" + Second;
            return res;
        }
    }
}