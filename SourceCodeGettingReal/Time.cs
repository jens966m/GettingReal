using System.ComponentModel.Design;

namespace SourceCodeGettingReal {
    public class Time {
        internal string Day;
        internal string Month;
        internal string Hour;
        internal string Year;
        internal string Minuttes;

        public override string ToString()
        {
            return Day + '/' + Month + '/' + Year + ' ' + Hour + ':' + Minuttes;
        }
    }
}