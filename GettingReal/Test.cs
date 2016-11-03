using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GettingReal {
    [TestClass]
    public class Test {
        [TestMethod]
        public void CustomerHasAName() {
            Customer customer = new Customer("Jens");
            Assert.AreEqual("Jens", customer.Name);
        }
    }
}
