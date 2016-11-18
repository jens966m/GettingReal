using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeGettingReal {
    public class Service {

        public string description { get; set; }
        public int price { get; set; }

        public Service(string _description, int _price) {
            description = _description;
            price = _price;
        }

        public Service(string _description) {
            description = _description;
        }
    }
}
