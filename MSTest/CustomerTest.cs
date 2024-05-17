using Biljettshoppen;
using Biljettshoppen.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void Test_Valid_Customer()
        {
            string name = "Samuel Back";
            string email = "vikarby.grill@gmail.com";
            string phoneNumber = "123456789";

            // Act
            var customer = new Customer(name, email, phoneNumber);

            // Assert
            Assert.AreEqual(name, customer.Name);
            Assert.AreEqual(email, customer.Email);
            Assert.AreEqual(phoneNumber, customer.Phonenumber);
        }

        [TestMethod]
        public void Test_Null_Email()
        {
            // Arrange
            string name = "Ralle Laurin";
            string email = null;
            string phoneNumber = "123456789";

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void Test_Null_PhoneNumber()
        {
            // Arrange
            string name = "Fredde Nygårds";
            string email = "samuel.vikarbygrill@example.com";
            string phoneNumber = null;

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void Test_Null_Name()
        {
            // Arrange
            string name = null;
            string email = "samuel.vikarbygrill@example.com";
            string phoneNumber = "123456789";

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void Test_Invalid_Email()
        {
            string name = "Karl Karlsson";
            // Email must contain @ and .
            string email = "blabla";
            string phoneNumber = "1234567";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void Test_Invalid_PhoneNumber()
        {
            // Arrange
            string name = "Samuel Back";
            string email = "hejhej@du.se";
            string phoneNumber = "123!!!abc";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void Test_Invalid_Name()
        {
            // Arrange
            string name = "Samuel b@c7";
            string email = "hejhej@du.se";
            string phoneNumber = "123456789";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }

    }
}