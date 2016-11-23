using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCodeGettingReal;

namespace UnitTestGettingReal {
    [TestClass]
    public class Test {
        UserFunctions userFunctions;
        Customer customer1;
        Customer customer2;
        Customer customer3;

        [TestInitialize]
        public void SetupTest() {
            userFunctions = new UserFunctions();
            userFunctions.Init();
            customer1 = new Customer(11111111);
            customer2 = new Customer(22222222);
            customer3 = new Customer(33333333);
            userFunctions.customers.Add(customer1);
            userFunctions.customers.Add(customer2);
            userFunctions.customers.Add(customer3);
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
            customer2.BookATime("12", "12", "2016", "12", "00");

            Assert.AreEqual("2016-12-12 12:00:00", customer2.Times[0].ToString());
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
