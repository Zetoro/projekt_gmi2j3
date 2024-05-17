using Biljettshoppen.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class Ticket
    {
        private Reservation reservation;

        public Reservation Reservation
        {
            get { return reservation; }
            set { reservation = value; }
        }

        public Ticket(Reservation reservation)
        {
            Reservation = reservation;
        }
    }
}
