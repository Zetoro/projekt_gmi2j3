using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen.Payment
{
    public class BillPayment : PaymentStrategy
    {
       public string Pay()
        {
            return "Pay By Bill";
        }


    }
}
