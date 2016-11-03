using System;
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
        public void ACustomerCanChooseATime() {
            Customer customer = new Customer();
            customer.Booktime(2016, 12, 24, 12, 00, 00); //hint DateTime      and       ToString("d/M/yyyy HH:mm")

            Assert.AreEqual("24-12-2016 12:00", customer.Time);
        }
    }
}
