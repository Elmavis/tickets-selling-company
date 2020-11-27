using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Abstract;
using Moq;

namespace tickets_selling.Controllers
{
    public class TestBDController : Controller
    {
        IRouteRepository repo;

        public TestBDController(IRouteRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult List()
        {
            return View(repo.GetAll());
        }

        //private List<Route> GetTestRoutes()
        //{
        //    var routes = new List<Route>
        //    {
        //        new Route {
        //            Id=1,
        //            DestinationName="Vitebsk",
        //            DepartureName ="Minsk",
        //            Status ="CANCELED",
        //            DepartureDateTime = new DateTime (2015, 7, 20, 15, 30, 25),
        //            ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25)
        //        },

        //        new Route {
        //            Id=2,
        //            DestinationName="Gomel",
        //            DepartureName ="Minsk",
        //            Status ="CANCELED",
        //            DepartureDateTime = new DateTime (2015, 7, 20, 21, 30, 25),
        //            ArrivalDateTime = new DateTime(2015, 7, 20, 23, 30, 25)
        //        },

        //        new Route {
        //            Id=3,
        //            DestinationName="Mogilev",
        //            DepartureName ="Minsk",
        //            Status ="CANCELED",
        //            DepartureDateTime = new DateTime (2015, 7, 15, 15, 30, 25),
        //            ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25)
        //        }
        //    };

        //    return routes;
        //}
    }
}
