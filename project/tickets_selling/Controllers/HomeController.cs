using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tickets_selling.Models;
using Domain.Entities;
using Domain.Abstract;
using Moq;

namespace tickets_selling.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRouteRepository routesRepo)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}
