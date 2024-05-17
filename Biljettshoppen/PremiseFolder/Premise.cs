using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Biljettshoppen
{
    public abstract class Premise
    {
        private string _location = "Unknown location";
        private bool[,] _seatReservations;

        public string location
        { get { return _location; } set { _location = value; } }
        public bool[,] seatReservations
        { get { return _seatReservations; } set { _seatReservations = value; } }
        public abstract string GetLocation();

        public abstract bool[,] GetSeats();

    }
}
