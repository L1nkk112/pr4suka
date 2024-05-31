using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp12
{
    public class Airplane<T, T1>
    {
        public T Destination { get; set; }
        public T PassangerName { get; set; }
        public T FlightNumber { get; set; }
        public T1 DepartureDate { get; set; }
        public Airplane(T destination, T passangerName, T flightNumber, T1 departureDate)
        {
            Destination = destination;
            PassangerName = passangerName;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
        }
    }
}