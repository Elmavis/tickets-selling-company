using System;
using System.Collections.Generic;
using System.Text;

namespace TicketsSellingAPIv3.Models
{
    [Serializable]
    public class RouteType
    {
        public int Id { get; set; }

        [NonSerialized]
        public string DestinationName;

        [NonSerialized]
        public string DepartureName;

        public string Route;

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        [NonSerialized]
        public decimal Price;

        public string Status { get; set; }

        public bool IsCanceled()
        {
            if (Status.Equals("CANCELED"))
                return true;
            return false;
        }

    }
}
