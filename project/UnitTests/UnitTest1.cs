using System;
using Xunit;
using Moq;
using Domain.Entities;
using Domain.Abstract;
using System.Collections;
using System.Collections.Generic;
using tickets_selling.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mock = new Mock<IRouteRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestRoutes());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Route>>(viewResult.Model);
            Assert.Equal(GetTestRoutes().Count, (model as List<Route>).Count);
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
                    DepartureName ="Minsk",
                    Status ="CANCELED",
                    DepartureDateTime = new DateTime (2015, 7, 15, 15, 30, 25),
                    ArrivalDateTime = new DateTime(2015, 7, 20, 18, 30, 25)
                }
            };

            return routes;
        }
    }
}
