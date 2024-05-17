using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen
{
    public class PremiseFactory
    {
        public Premise TypeOfPremise(String type)
        {
            Premise premise = null;
            if(type == "brick")
            {
                premise = new Premise1();
            }
            else if (type == "wood")
            {
                premise = new Premise2();
            }
            else
            {
                throw new InvalidDataException("Invalid type of premise.");
            }

            return premise;
        }   
    }
}
