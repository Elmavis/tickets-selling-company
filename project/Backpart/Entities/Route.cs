using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string DestinationName { get; set; }
        public string DepartureName { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public bool IsCanceled()
        {
            if (Status.Equals("CANCELED"))
                return true;
            return false;
        }

    }
}
