using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketsSellingAPIv3.Models
{
    [Serializable]
    public class Cart
    {
        private List<CartLine> routesInCart = new List<CartLine>();

        public void AddItem(RouteType route, int quantity)
        {
            string routeToString = (route.DepartureName + "-" + route.DestinationName);

            CartLine routeLine = routesInCart
                .Where(r => r.Route == routeToString)
                .FirstOrDefault();

            if (routeLine == null)
            {
                routesInCart.Add(new CartLine
                {
                    Id = route.Id,
                    Quantity = quantity,
                    Route = routeToString,
                    Price = route.Price,
                    TotalPrice = route.Price * quantity
                }); ;
            }
            else
            {
                routeLine.Quantity += quantity;
            }
        }

        public void RemoveItem(RouteType route)
        {
            routesInCart.RemoveAll(r => r.Id == route.Id);
        }

        public decimal ComputeTotalValue()
        {
            return routesInCart.Sum(e => e.Price = e.Quantity);
        }

        public void Clear()
        {
            routesInCart.Clear();
        }

        public IEnumerable<CartLine> GetItems()
        {
            return routesInCart;
        }
    }

    [Serializable]
    public class CartLine
    {
        [NonSerialized]
        public int Id;

        public int Quantity;

        public string Route;

        public decimal Price;

        public decimal TotalPrice;
    }
}
