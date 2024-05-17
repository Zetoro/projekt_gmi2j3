using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen.Events
{
    public static class ActiveOcassions
    {

        private static List<Ocassion> ocassions;

        public static List<Ocassion> Ocassions = new List<Ocassion>();
        //{ get { return ocassions; } set { ocassions = value; } }

        /*public  ActiveOcassions()
        {
            ocassions = new List<Ocassion>(); 
        } */
        public static void AddOcassion(Ocassion ocassion)
        {
            Ocassions.Add(ocassion);
        }
        public static void PrintAllOcassions()
        {
            int number = 0;
            foreach (var concert in Ocassions)
            {

                Console.WriteLine("Concert:" + number);
                Console.WriteLine("Concert Name: " + concert.OcassionName);
                Console.WriteLine("Performer: " + concert.OcassionPerformer);
                Console.WriteLine("Concert Type: " + concert.OcassionType);
                Console.WriteLine("Date: " + concert.OcassionDate);
                Console.WriteLine("Premise Type: " + concert.premiseSet.GetLocation());
                Console.WriteLine();
                number++;
            }
        }
    }
}
