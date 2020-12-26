using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicketsSellingAPIv3.Models
{
    public interface IRouteRepository
    {
        IEnumerable<RouteType> GetAll();
        IEnumerable<RouteType> GetRoutesByDepartureName(string departureName);
        IEnumerable<RouteType> GetRoutesByDestinationName(string destinationName);
        IEnumerable<RouteType> GetRoutesByNamesAndDate(string departureName, string destinationName, 
            DateTime departureDateTime);
    }

    //Реализация извлечения части лежит здесь:
    //GetRouteBy DepartureDate
    //GetRouteBy DepartureName
    //GetRouteBy DestinationName
    //GetRoutesBy NamesAndDate
    //
    //Но сделать это после реализации контроллера и кнопки
    public class RouteRepository : IRouteRepository
    {
        List<RouteType> routes;
        public IEnumerable<RouteType> GetRoutesByDepartureName(string departureName)
        {
            List<RouteType> slice = new List<RouteType>();
            foreach (RouteType route in routes)
            {
                if (route.DepartureName.Equals(departureName))
                    slice.Add(route);
            }
            return slice;
        }
        public IEnumerable<RouteType> GetRoutesByDestinationName(string destinationName)
        {
            List<RouteType> slice = new List<RouteType>();
            foreach (RouteType route in routes)
            {
                if (route.DestinationName.Equals(destinationName))
                    slice.Add(route);
            }
            return slice;
        }

        public IEnumerable<RouteType> GetRoutesByDepartureDateTime(DateTime departureDateTime)
        {
            List<RouteType> slice = new List<RouteType>();
            foreach (RouteType route in routes)
            {
                if (route.DepartureDateTime.Date.Equals(departureDateTime.Date))
                    slice.Add(route);
            }
            return slice;
        }

        //неправильно, после заменить на LINQ
        public IEnumerable<RouteType> GetRoutesByNamesAndDate(string departureName,
            string destinationName, DateTime departureDateTime)
        {
            var myRoutes = (routes as List<RouteType>);
            var resultRoutes = from route in myRoutes
                               where route.DepartureName.Equals(departureName)
                               where route.DestinationName.Equals(destinationName)
                               where route.DepartureDateTime.Date.Equals(departureDateTime.Date)
                               select route;

            if (resultRoutes.Count() == 0)
                return null;
            else return resultRoutes.ToArray();
        }


        public RouteRepository()
        {
            routes = GetTestRoutes();
        }

        public IEnumerable<RouteType> GetAll()
        {
            return routes;
        }

        private List<RouteType> GetTestRoutes()
        {
            var routes = new List<RouteType>
            {
                new RouteType {
                    Id=1,
                    DestinationName="Vitebsk",
                    DepartureName ="Minsk",
                    Route="Minsk-Vitebsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 20, 15, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25),
                    Price = 15
                },

                new RouteType {
                    Id=2,
                    DestinationName="Gomel",
                    DepartureName ="Minsk",
                    Route="Minsk-Gomel",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 20, 21, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 23, 30, 25),
                    Price = 10
                },

                new RouteType {
                    Id=3,
                    DestinationName="Mogilev",
                    DepartureName ="Soligorsk",
                    Route="Soligorsk-Mogilev",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 15, 15, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25),
                    Price = 11
                }
            };

            return routes;
        }
    }

}
