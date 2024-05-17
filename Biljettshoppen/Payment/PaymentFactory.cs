using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen.Payment
{
    public abstract class PaymentFactory
    {
        public PaymentStrategy TypeOfPayment(String type)
        {
            PaymentStrategy paymentStrategy = null;
            if(type == "Card")
            {
                paymentStrategy = new CardPayment();
            }
            else if(type == "Bill")
            {
                paymentStrategy = new BillPayment(); 
            }
            return paymentStrategy;
        }
    }
}
