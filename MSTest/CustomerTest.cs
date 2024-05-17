using Biljettshoppen;
using Biljettshoppen.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class CustomerTest
    {

        [TestMethod]
        public void TestValidCustomer()
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
        public void TestInvalidEmail()
        {
            string name = "Karl Karlsson";
            // Email must contain @ and .
            string email = "blabla";
            string phoneNumber = "1234567";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));

        }

        [TestMethod]
        public void TestNullEmail()
        {
            // Arrange
            string name = "John Doe";
            string email = null;
            string phoneNumber = "123456789";

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void TestNullPhoneNumber()
        {
            // Arrange
            string name = "John Doe";
            string email = "john.doe@example.com";
            string phoneNumber = null;

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void TestInvalidPhoneNumber()
        {
            // Arrange
            string name = "John Doe";
            string email = "hejhej@du.se";
            string phoneNumber = "123!!!abc";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }
        [TestMethod]
        public void TestInvalidName()
        {
            // Arrange
            string name = "John Doe123";
            string email = "hejhej@du.se";
            string phoneNumber = "123456789";

            Assert.ThrowsException<InvalidDataException>(() => new Customer(name, email, phoneNumber));
        }

    }
}