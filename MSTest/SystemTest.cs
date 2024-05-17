using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biljettshoppen.Events;
using Biljettshoppen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biljettshoppen.Payment;
using Moq;

namespace MSTest
{
    [TestClass]
    public class SystemTest
    {
        [TestMethod]
        public void Test_Booking_Reserved_Seat()
        {
            Customer customer1 = new Customer("Fredrik Nilsen Nygårds", "h21freny@du.se", "00441110");
            Ocassion ocassion1 = new Ocassion("RockStar", "Rasmus", "Consert", "2024/07/22 22:00", "brick");
            Reservation reservation = new Reservation(customer1, ActiveOcassions.Ocassions[0]);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[0].premiseSet.seatReservations, 1, 1);
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                reservation.ReserveSeat(ActiveOcassions.Ocassions[0].premiseSet.seatReservations, 1, 1);
            });
        }
        [TestMethod]
        public void Test_Booking_Seat_Wrong_Input()
        {
            Customer customer1 = new Customer("Fredrik Nilsen Nygårds", "h21freny@du.se", "00441110");
            Ocassion ocassion1 = new Ocassion("RockStar", "Rasmus", "Consert", "2024/09/22 22:00", "brick");
            Reservation reservation = new Reservation(customer1, ActiveOcassions.Ocassions[0]);
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                reservation.ReserveSeat(ActiveOcassions.Ocassions[0].premiseSet.seatReservations, 50, 50);
            });
        }
        [TestMethod]
        public void Test_Booking_Too_Many_Seats()
        {
            Customer customer3 = new Customer("Fredrik Nygårds", "h21freny@du.se", "00441110");
            Ocassion ocassion3 = new Ocassion("RockStar", "Rasmus", "Consert", "2026/03/22 22:00", "brick");
            Reservation reservation = new Reservation(customer3, ActiveOcassions.Ocassions[2]);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 1);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 2);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 3);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 4);
            reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 5);
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                reservation.ReserveSeat(ActiveOcassions.Ocassions[2].premiseSet.seatReservations, 1, 6);
            });
        }
        [TestMethod]
        public void Test_Choose_Nonexisting_Event()
        {
            Customer customer1 = new Customer("Fredrik Nilsen Nygårds", "h21freny@du.se", "00441110");
            Ocassion ocassion1 = new Ocassion("RockStar", "Rasmus", "Consert", "2024/07/08 22:00", "brick");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Reservation reservation = new Reservation(customer1, ActiveOcassions.Ocassions[8]);
            });
        }
        [TestMethod]
        public void TypeOfPayment_ShouldReturnCardPayment_WhenTypeIsCard()
        {
            var factory = new Mock<PaymentFactory> { CallBase = true };

            var result = factory.Object.TypeOfPayment("Card");

            Assert.IsInstanceOfType(result, typeof(CardPayment));
            Assert.AreEqual("Pay By Card", result.Pay());
        }
        [TestMethod]
        public void TypeOfPayment_ShouldReturnBillPayment_WhenTypeIsBill()
        {
            var factory = new Mock<PaymentFactory> { CallBase = true };

            var result = factory.Object.TypeOfPayment("Bill");

            Assert.IsInstanceOfType(result, typeof(BillPayment));
            Assert.AreEqual("Pay By Bill", result.Pay());
        }
    }
}
