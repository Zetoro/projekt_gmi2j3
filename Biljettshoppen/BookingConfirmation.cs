using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class BookingConfirmation 
    {
        private Ticket ticket;
        
        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        } 

        public BookingConfirmation(Ticket ticket)
        {
            Ticket = ticket;
            if(ticket != null) 
            {
                SendEmail();
            }
        }

        public void SendEmail() 
        {
            Console.WriteLine("En Bokningsbekräftelse har skickats till " + ticket.Reservation.Customer.Email);
            Console.WriteLine("-----------------------------------------------------------");
        }

    }
}
