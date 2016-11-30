using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCodeGettingReal;

namespace UnitTestGettingReal {
    [TestClass]
    public class Test {
        UserFunctions userFunctions;
        Menu menu;

        Customer customer1;
        Customer customer2;
        Customer customer3;

        Haircutter haircutter1;
        Haircutter haircutter2;

        [TestInitialize]
        public void SetupTest() {
            userFunctions = new UserFunctions();
            userFunctions.Init();

            menu = new Menu();
            menu.Init();

            customer1 = new Customer(11111111);
            customer2 = new Customer(22222222);
            customer3 = new Customer(33333333);
            userFunctions.customers.Add(customer1);
            userFunctions.customers.Add(customer2);
            userFunctions.customers.Add(customer3);

            haircutter1 = new Haircutter("Louise");
            haircutter2 = new Haircutter("Jesper");
            menu.haircutters.Add(haircutter1);
            menu.haircutters.Add(haircutter2);


        }
        [TestMethod]
        public void CustomerHaveAName() {
            customer1.Name = "Jens";
            customer1.LastName = "Dideriksen";

            Assert.AreEqual("Jens", customer1.Name);
            Assert.AreEqual("Dideriksen", customer1.LastName);
            Assert.AreEqual(11111111, customer1.Phone);
        }
        [TestMethod]
        public void ACustomerCanChooseATime() {
            //test
            customer2.BookATime("12", "12", "2016", "12", "00", "00");

            Assert.AreEqual("12-12-2016 12:00:00", customer2.Times[0].ToString());
        }
        [TestMethod]
        public void FindCustomerByPhone() {
            customer3.Name = "Peter";
            Assert.AreEqual(userFunctions.FindCustomerByPhone(33333333), customer3);
        }
        [TestMethod]
        public void ShowListOfCusomers() {
            customer1.Name = "Jan";
            customer1.LastName = "Jansen";
            customer2.Name = "Bobby";
            customer2.LastName = "Olsen";
            customer3.Name = "Rut";
            customer3.LastName = "Rutsen";

            userFunctions.ListCustomers();
        }

        //HAIRCUTTER
        [TestMethod]
        public void HaircutterHasAName() {
            Assert.AreEqual(haircutter1.Name, "Louise");
        }
        [TestMethod]
        public void AHaircutterCanFindNextTime() {
            haircutter1.Times.Add(new DateTime(2016, 12, 12, 20, 00, 00));
            haircutter1.Times.Add(new DateTime(2016, 12, 12, 18, 00, 00));
            haircutter1.Times.Add(new DateTime(2016, 12, 13, 18, 00, 00));
            haircutter1.Times.Add(new DateTime(2016, 12, 17, 17, 00, 00));
            haircutter1.Times.Add(new DateTime(2016, 12, 24, 01, 00, 00));
            
            Assert.AreEqual("12-12-2016 18:00:00", haircutter1.NextTime().ToString());
        }
        [TestMethod]
        public void FindCustomerByTime() {
            haircutter1.Times.Add(new DateTime(2016, 12, 12, 18, 00, 00));
            customer1.Times.Add(new DateTime(2016, 12, 12, 17, 00, 00));
            customer2.Times.Add(new DateTime(2016, 12, 12, 20, 00, 00));
            customer2.Times.Add(new DateTime(2016, 12, 12, 18, 00, 00));
            DateTime nextTime = haircutter1.NextTime();
            Assert.AreEqual(userFunctions.FindCustomerByTime(nextTime, "Louise"), customer2);
        }

        //SERVICE
        [TestMethod]
        public void ServiceHasADescriptionAndPrice() {

            Service service1;
            Service service2;
            service1 = new Service("Herreklip", 250);

            service2 = new Service("Dameklip", 400);

            service1.description = "Herreklip";
            service1.price = 250;


            Assert.AreEqual("Herreklip", service1.description);

            Assert.AreEqual(250, service1.price);
        }
        [TestMethod]
        public void ChangeDescription() {
            Service s = new Service("Herreklip");
            Assert.AreEqual("Herreklip", s.description);
            s.description = "Anden slags klip";
            Assert.AreEqual("Anden slags klip", s.description);
        }
    }
}
