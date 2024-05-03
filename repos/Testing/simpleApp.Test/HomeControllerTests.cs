using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleApp.Controllers;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace simpleApp.Test
{
   public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            //public FakeDataSource(Product[] data)
            //{
            //    products = data;
            //}
            //public IEnumerable<Product> products {get;set;}
        }
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange

            
            Product[] textData = new Product[] {
            new Product { Name = "Kayak", Price = 275M },
            new Product { Name = "Lifejacket", Price = 48.95M}
            };
            //IDataSource data = new FakeDataSource(textData);
            //var controller = new HomeController();
            //controller.datasource = data;
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.products).Returns(textData);
            var controller = new HomeController();
            controller.datasource = mock.Object;

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Product>;
            // Assert
            Assert.Equal(textData, model,
            Comparer.Het<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
