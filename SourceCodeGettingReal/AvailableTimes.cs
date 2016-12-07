using System;
using System.Collections;

namespace SourceCodeGettingReal {
    public class AvailableTimes {
        public string Date;

        public int openHour;
        public int openMin;
        public int closedHour;
        public int closedMin;

        public BitArray Available;

        public AvailableTimes(string date, string day) {
            Date = date;
            if (day == "Tuesday" || day == "Wednesday") {
                openHour = 09;
                openMin = 00;
                closedHour = 17;
                closedMin = 30;
            } else if (day == "Thursday") {
                openHour = 11;
                openMin = 00;
                closedHour = 19;
                closedMin = 00;
            } else if (day == "Friday") {
                openHour = 09;
                openMin = 00;
                closedHour = 16;
                closedMin = 00;
            }
    
        }

        public void Init() {
            int MinOfDay = ((closedHour-openHour) * 60) + closedMin-openMin;
            Available = new BitArray(MinOfDay, true);
        }
        public void BookTime(string beginTime, int length) {
            string[] time = beginTime.Split(':');
            int Start = ((Convert.ToInt32(time[0]) - openHour) * 60) + ((Convert.ToInt32(time[1]) - openMin));
            for (int i = 0; i < length; i++) {
                Available[Start + i] = false;
            }
        }

        public string ShowTimes() {
            string Result = "";
            bool available2 = false;
            for (int i = 0; i < Available.Length; i++) {
                if (Available[i] == true && available2 == false) {
                    available2 = true;
                    Result += calcTime(i) + " ";
                } else if (Available[i] == false && available2 == true) {
                    available2 = false;
                    Result += calcTime(i) + " ";
                } else if (i+1 == Available.Length && available2 == true) {
                    Result += calcTime(i+1);
                }
            }
            //Format: is true: fra til fra til....
            //e.g. "09:00 11:00 11:15 11:45 13:00 15:00"
            return Result.TrimEnd(' ');
        }

        public string calcTime(int i) {
            return ((i / 60)+openHour).ToString("00") + ":" + ((i % 60)+openMin).ToString("00");
        }
    }
}