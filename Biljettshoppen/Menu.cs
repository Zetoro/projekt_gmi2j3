using Biljettshoppen.Events;
using Biljettshoppen.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class Menu
    {
        public static void StartMenu()
        {
            //ActiveOcassions activeEvents = new ActiveOcassions();
            int choice;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Köp Biljetter");
                Console.WriteLine("2. Skapa ett Evenemang");
                Console.WriteLine("3. Exit");
                Console.Write("Val: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            var result = VäljEvent(/*activeEvents */);
                            Ocassion ocassion1 = result.Item1;
                            int number1 = result.Item2;
                            Customer customer1 = AngeKundInformation();
                            Reservation reservation = SkapaEnResevation(ocassion1, customer1);
                            BokaSittplatser(number1, /*activeEvents , */ reservation);
                            Betala(reservation);
                            break;
                        case 2:
                            Console.Clear();
                            SkapaEvent(/*activeEvents */);
                            break;
                        case 3:
                            Console.WriteLine("Exiting the program.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number (1, 2, or 3).");
                }
            } while (choice != 3);
        }
        public static (Ocassion, int) VäljEvent(/*ActiveOcassions activeEvemts */)
        {
            Console.Clear();
            ActiveOcassions.PrintAllOcassions();
            // activeEvemts.PrintAllOcassions();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Välj Event:");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            return (/*activeEvemts.Ocassions[number], number */ActiveOcassions.Ocassions[number], number);
        }
        public static Customer AngeKundInformation()
        {
            Console.Clear();
            Console.Write("Skriv ditt Namn: ");
            string name = Console.ReadLine();
            Console.Write("Skriv ditt telefonnummer: ");
            string phonenumber = Console.ReadLine();
            Console.Write("Skriv din email: ");
            string email = Console.ReadLine();

            Customer customer = new Customer(name, email, phonenumber);
            return customer;
        }
        public static Reservation SkapaEnResevation(Ocassion ocassion, Customer customer)
        {
            Reservation reservation = new Reservation(customer, ocassion);
            return reservation;
        }
        public static Ocassion BokaSittplatser(int number,/* activeEvemts , */Reservation reservation)
        {
            bool continueBooking = true;
            int maximumSeats = 0;

            while (continueBooking)
            {
                Console.Clear();
                reservation.DisplaySeatStatus(ActiveOcassions.Ocassions[number].premiseSet.seatReservations /*activeEvemts.Ocassions[number].premiseSet.seatReservations */);
                Console.Write("Välj en ledig rad:");
                string userInput2 = Console.ReadLine();
                int number2 = int.Parse(userInput2);
                Console.Write("Välj lediga sittplatser:");
                string userInput3 = Console.ReadLine();
                int number3 = int.Parse(userInput3);
                reservation.ReserveSeat(ActiveOcassions.Ocassions[number].premiseSet.seatReservations, number2, number3 /*activeEvemts.Ocassions[number].premiseSet.seatReservations, number2, number3 */);
                Console.WriteLine($"Du kan välja max 5 platser, just nu har du {maximumSeats + 1} platser");
                Console.WriteLine("För att välja en till plats skriv ja annars skriv nej");
                string userInput4 = Console.ReadLine();
                if (userInput4 == "ja")
                {
                    continueBooking = true;
                    maximumSeats++;
                }
                else
                {
                    continueBooking = false;
                }

            }
            return ActiveOcassions.Ocassions[number];  //activeEvemts.Ocassions[number];
        }
        public static void Betala(Reservation reservation)
        {
            Console.Clear();
            Console.WriteLine("..............................BookingInformations.....................................");
            Console.WriteLine("Kund information:");
            Console.WriteLine(reservation.Customer.Name);
            Console.WriteLine(reservation.Customer.Phonenumber);
            Console.WriteLine(reservation.Customer.Email);
            Console.WriteLine("...............................................");
            Console.WriteLine("Event information:");
            Console.WriteLine(reservation.Ocassion.OcassionName);
            Console.WriteLine(reservation.Ocassion.OcassionPerformer);
            Console.WriteLine(reservation.Ocassion.OcassionDate);
            Console.WriteLine(reservation.Ocassion.premiseSet.GetLocation());
            Console.WriteLine("...............................................");
            Console.WriteLine("Bokade sittplatser:");
            foreach (int rows in reservation.Bookedseats)
            {
                Console.WriteLine("Bokad Sittplats:" + rows);
            }


            Console.WriteLine("Vill du Betala skriv ja:");

            string svar = Console.ReadLine();
            if (svar == "ja")
            {
                SendBookingConfirmation(CreateTicket(reservation));
            }
            else
            {

            }
        }

        public static Ticket CreateTicket(Reservation reservation)
        {
            Ticket ticket = new Ticket(reservation);
            return ticket;

        }
        public static void SendBookingConfirmation(Ticket ticket)
        {
            Console.Clear();
            BookingConfirmation bookingconfirmation = new BookingConfirmation(ticket);
        }

        public static void SkapaEvent(/*ActiveOcassions activeEvemts */)
        {
            Console.Clear();
            Console.Write("Enter the Ocassion name: ");
            string ocassionName = Console.ReadLine();
            Console.Write("Ocassion performer: ");
            string ocassionPerformer = Console.ReadLine();
            Console.Write("Enter the Ocassiono type: ");
            string ocassionType = Console.ReadLine();
            Console.Write("Enter a date. (yyyy-mm-dd HH:MM): ");
            string ocassionDate = Console.ReadLine();
            //DateTime ocassionDate = DateTime.Parse(date);

            Console.WriteLine("Type brick for brick premise");
            Console.WriteLine("Type wood for the wood premise");
            Console.Write("Enter the Type of premise: ");
            string typeOfPremise = Console.ReadLine();


            Ocassion concert1 = new Ocassion(ocassionName, ocassionPerformer, ocassionType, ocassionDate, typeOfPremise);
            //ActiveOcassions.AddOcassion(concert1);
            //activeEvemts.AddOcassion(concert1);
        }
    }
}
