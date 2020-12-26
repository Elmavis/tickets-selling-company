using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Abstract;
using tickets_selling.Models;

namespace tickets_selling.Controllers
{
    //После добавить сессию
    public class CartController : Controller
    {
        private IRouteRepository repository;
        private static Cart cart = new Cart();

        public CartController(IRouteRepository repository)
        {
            this.repository = repository;
        }

        //changed
        [HttpGet]
        public RedirectToActionResult AddToCart(int routeId, string returnUrl)
        {
            Route route = repository.GetAll().FirstOrDefault(repository => repository.Id == routeId);

            if (route != null)
            {
                cart.AddItem(route, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpGet]
        public RedirectToActionResult RemoveFromCart(int routeId, string returnUrl)
        {
            Route route = repository.GetAll().FirstOrDefault(repository => repository.Id == routeId);

            if (route != null)
            {
                cart.RemoveItem(route);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpGet]
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
    }
}
