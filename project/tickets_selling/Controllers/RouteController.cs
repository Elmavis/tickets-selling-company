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
    public class RouteController : Controller
    {
        IRouteRepository routesRepository;

        public RouteController(IRouteRepository repository)
        {
            this.routesRepository = repository;
        }

        public ViewResult List()
        {
            return View(routesRepository.GetAll());
        }

        public ViewResult GetRoutesByNamesAndDate(string destinationName, string departureName, 
            string departureDate)
        {
            DateTime departureDateTime = DateTime.Parse(departureDate);
            return View(routesRepository.GetRoutesByNamesAndDate(departureName, destinationName,
                departureDateTime));
        }
    }
}
