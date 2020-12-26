using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Entities
{
    public class Cart
    {
        private List<RouteLine> routesInCart = new List<RouteLine>();

        public void AddItem(Route route, int quantity)
        {
            RouteLine routeLine = routesInCart
                .Where(r => r.Route.Id == route.Id)
                .FirstOrDefault();

            if (routeLine == null)
            {
                routesInCart.Add(new RouteLine
                {
                    Route = route,
                    Quantity = quantity
                });
            }
            else
            {
                routeLine.Quantity += quantity;
            }
        }

        public void RemoveItem(Route route)
        {
            routesInCart.RemoveAll(r => r.Route.Id == route.Id);
        }

        public decimal ComputeTotalValue()
        {
            return routesInCart.Sum(e => e.Route.Price = e.Quantity);
        }

        public void Clear()
        {
            routesInCart.Clear();
        }

        public IEnumerable<RouteLine> GetItems()
        {
            return routesInCart;
        }

    }

    public class RouteLine
    {
        public Route Route { get; set; }

        public int Quantity { get; set; }
    }
}
