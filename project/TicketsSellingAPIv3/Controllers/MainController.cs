using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json;
using TicketsSellingAPIv3.Models;

namespace TicketsSellingAPIv3.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        IRouteRepository _routeRepository;
        private Cart[] carts = new Cart[10000];
        private int maxUserId = 1;


        public MainController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository; // добавить в DI
        }


        [HttpGet]
        public string AddToCart(int routeId, int userId)
        {
            RouteType route = _routeRepository.GetAll().FirstOrDefault(repository => repository.Id == routeId);

            if (route != null)
            {
                carts[userId].AddItem(route, 1);
            }

            return "OK";
        }

        [HttpGet]
        public string RemoveFromCart(int routeId, int userId)
        {
            RouteType route = _routeRepository.GetAll().FirstOrDefault(repository => repository.Id == routeId);

            if (route != null)
            {
                carts[userId].RemoveItem(route);
            }
            return "OK";
        }

        [HttpGet]
        public string GetRoutesByNamesAndDate(string destinationName, string departureName,
            string departureDate)
        {
            DateTime departureDateTime = DateTime.Parse(departureDate);
            var list = _routeRepository.GetRoutesByNamesAndDate(departureName, destinationName,
                departureDateTime);

            return JsonSerializer.Serialize(list);
        }

        [HttpGet]
        public string GetRoutsOfCart(int userId)
        {
            var cartItems = carts[userId].GetItems();
            return JsonSerializer.Serialize(cartItems);
        }
        
        [HttpGet]
        public int GetId()
        {
            return maxUserId++;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
