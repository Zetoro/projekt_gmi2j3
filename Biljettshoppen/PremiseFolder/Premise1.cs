using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class Premise1 : Premise
    {
        public Premise1()
        {
            seatReservations = GetSeats(); 
            location = GetLocation();
        }
        public override string GetLocation()
        {
            return "Brick house";
        }
        public override bool[,] GetSeats()
        {
            int rows = 4;
            int seatsPerRow = 12;

            bool[,] seatReservations = new bool[rows, seatsPerRow];

            for (int row = 0; row < rows; row++)
            {
                for (int seat = 0; seat < seatsPerRow; seat++)
                {
                    seatReservations[row, seat] = false;
                }
            }
            return seatReservations;
        }
        /*
        public override bool[] GetSeats()
        {
            int seats = 50;

            // Create an array to represent seat reservations
            bool[] seatReservations = new bool[seats];

            // Initialize all seats as unreserved
            for (int i = 0; i < seats; i++)
            {
                seatReservations[i] = false;
            }
            return seatReservations;
        } */
    }
}
