using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetAll();

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
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25)
                },

                new Route {
                    Id=2,
                    DestinationName="Gomel",
                    DepartureName ="Minsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 20, 21, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 23, 30, 25)
                },

                new Route {
                    Id=3,
                    DestinationName="Mogilev",
                    DepartureName ="Soligorsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 15, 15, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25)
                }
            };

            return routes;
        }
    }

}
