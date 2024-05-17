using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biljettshoppen.Events;
using Biljettshoppen.Interfaces;
using Biljettshoppen.Payment;

namespace Biljettshoppen
{
    public class Reservation
    {
        private int seats = 0;
        public int Seats { get { return seats; } set { seats = value; } }
        private Ocassion ocassion;
        private Customer customer;
        private List<int> bookedseats;
        PaymentStrategy paymentStrategy;
        PaymentFactory paymentFactory;
        private float timer;

        public Ocassion Ocassion { get { return ocassion; } set { ocassion = value; } }
        public Customer Customer { get { return customer; } set { customer = value; } }
        public List <int> Bookedseats { get { return bookedseats; } set { bookedseats = value; } }
        public float Timer { get { return timer; } set { timer = value; } }

        public Reservation( Customer customer, Ocassion ocassion)
        {
                Customer = customer;
                Ocassion = ocassion;
                Bookedseats = new List<int>();
        }
        public void DisplaySeatStatus(bool[,] reservations)
        {
            Console.WriteLine("Tillgängliga säten:");
            int rows = reservations.GetLength(0);
            int seatsPerRow = reservations.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine($"Rad {row + 1}:");

                for (int seat = 0; seat < seatsPerRow; seat++)
                {
                    Console.WriteLine($"Säte {seat + 1}: {(reservations[row, seat] ? "Reserverad" : "Tillgänglig")}");
                }

                Console.WriteLine();
            }
        }
        public void ReserveSeat(bool[,] reservations, int row, int seat)
        {
            if (Seats < 5)
            {
                int rows = reservations.GetLength(0);
                int seatsPerRow = reservations.GetLength(1);

                if (row > 0 && row <= rows && seat > 0 && seat <= seatsPerRow)
                {
                    if (!reservations[row - 1, seat - 1])
                    {
                        reservations[row - 1, seat - 1] = true;
                        Console.WriteLine($"Plats {row}-{seat} har blivit reserverad.");
                        Seats++;

                    }
                    else
                    {
                        throw new InvalidDataException("Sätet är redan reserverat");
                    }
                }
                else
                {
                    throw new InvalidDataException("Fel rad eller sätesnummer.");
                }
            }
            else
            {
                throw new InvalidDataException("Du Kan inte boka mer än 5 säten");
            }
        }
        /*
        public void DisplaySeatStatus(bool[] reservations)
        {
            Console.WriteLine("Seat Reservations:");
            for (int i = 0; i < reservations.Length; i++)
            {
                Console.WriteLine($"Seat {i + 1}: {(reservations[i] ? "Reserved" : "Available")}");
            }
            Console.WriteLine();
        }
        

        public void ReserveSeat(bool[] reservations, int seatNumber)
        {
            if (seatNumber > 0 && seatNumber <= reservations.Length)
            {
                if (!reservations[seatNumber - 1])
                {
                    reservations[seatNumber - 1] = true;
                    Console.WriteLine($"Seat {seatNumber} has been reserved.");
                    Bookedseats.Add(seatNumber);
                }
                else
                {
                    Console.WriteLine($"Seat {seatNumber} is already reserved.");
                }
            }
            else
            {
                Console.WriteLine("Invalid seat number.");
            }
        }
        */
        public void Pay()
        {
          paymentStrategy.Pay();
        }
        public void setPaymentStrategy()
        {
          string input = Console.ReadLine();
          paymentStrategy = paymentFactory.TypeOfPayment(input);
        }


    }
}
