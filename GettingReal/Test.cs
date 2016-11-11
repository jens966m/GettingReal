using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GettingReal {
    [TestClass]
    public class Test {
        [TestMethod]
        public void CustomerHaveAName() {
            Customer customer = new Customer();
            customer.Name = "Jens";
            Assert.AreEqual("Jens", customer.Name);
        }
        [TestMethod]
        public void ACustomerCanChooseATime()
        {
            Customer customer = new Customer();
            customer.Times = new List<Time>();

            customer.BookATime("12", "12", "2016", "12", "00");
            
            Assert.AreEqual("12/12/2016 12:00", customer.Times[0].ToString());
            
        }
    }
}
