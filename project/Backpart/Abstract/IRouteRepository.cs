using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;

namespace Domain.Abstract
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetAll();
        IEnumerable<Route> GetRoutesByDepartureName(string departureName);
        IEnumerable<Route> GetRoutesByDestinationName(string destinationName);
        IEnumerable<Route> GetRoutesByNamesAndDate(string departureName, string destinationName, 
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
        List<Route> routes;
        public IEnumerable<Route> GetRoutesByDepartureName(string departureName)
        {
            List<Route> slice = new List<Route>();
            foreach (Route route in routes)
            {
                if (route.DepartureName.Equals(departureName))
                    slice.Add(route);
            }
            return slice;
        }
        public IEnumerable<Route> GetRoutesByDestinationName(string destinationName)
        {
            List<Route> slice = new List<Route>();
            foreach (Route route in routes)
            {
                if (route.DestinationName.Equals(destinationName))
                    slice.Add(route);
            }
            return slice;
        }

        public IEnumerable<Route> GetRoutesByDepartureDateTime(DateTime departureDateTime)
        {
            List<Route> slice = new List<Route>();
            foreach (Route route in routes)
            {
                if (route.DepartureDateTime.Date.Equals(departureDateTime.Date))
                    slice.Add(route);
            }
            return slice;
        }

        //неправильно, после заменить на LINQ
        public IEnumerable<Route> GetRoutesByNamesAndDate(string departureName,
            string destinationName, DateTime departureDateTime)
        {
            var myRoutes = (routes as List<Route>);
            var resultRoutes = from route in myRoutes
                               where route.DepartureName.Equals(departureName)
                               where route.DestinationName.Equals(destinationName)
                               where route.DepartureDateTime.Date.Equals(departureDateTime.Date)
                               select route;

            if (resultRoutes.Count() == 0)
                return null;
            else return resultRoutes;
        }


        public RouteRepository()
        {
            routes = GetTestRoutes();
        }

        public IEnumerable<Route> GetAll()
        {
            return routes;
        }

        private List<Route> GetTestRoutes()
        {
            var routes = new List<Route>
            {
                new Route {
                    Id=1,
                    DestinationName="Vitebsk",
                    DepartureName ="Minsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 20, 15, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25),
                    Price = 15
                },

                new Route {
                    Id=2,
                    DestinationName="Gomel",
                    DepartureName ="Minsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 20, 21, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 23, 30, 25),
                    Price = 10
                },

                new Route {
                    Id=3,
                    DestinationName="Mogilev",
                    DepartureName ="Soligorsk",
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
