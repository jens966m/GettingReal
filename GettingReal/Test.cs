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
            customer.LastName = "Dideriksen";
            customer.Phone = 88888888;

            Assert.AreEqual("Jens", customer.Name);
            Assert.AreEqual("Dideriksen", customer.LastName);
            Assert.AreEqual(88888888, customer.Phone);
        }
        [TestMethod]
        public void ACustomerCanChooseATime()
        {
            Customer customer = new Customer();
            customer.Times = new List<Time>();

            customer.BookATime("12", "12", "2016", "12", "00");
            
            Assert.AreEqual("12/12/2016 12:00", customer.Times[0].ToString());
            
        }
        [TestMethod]
        public void AddCustomerToList() {
            Customer person2 = new Customer(11111111);
            person2.Name = "Peter";
            .customers.Add(person2);

            Customer FoundPerson = .FindCustomerByPhone(11111111);

            Assert.AreEqual(FoundPerson, person2);
        }
    }
}
