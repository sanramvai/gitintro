using FinalLessons.Controllers;
using FinalLessons.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FinalLesson.Test
{
    public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] datad)
            {
                Products = datad;
            }

            public IEnumerable<Product> Products {get;set;}
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
                       var controller = new HomeController();
                       Product[] fakeproduct = new Product[] {
                            new Product { Name = "P1", Price = 75.10M },
                            new Product { Name = "P2", Price = 120M },
                            new Product { Name = "P3", Price = 110M }
                        };
            //            IDataSource fakesource = new FakeDataSource(fakeproduct);
            //            controller.dataSource = fakesource;
            //            var model = ((controller.Index()) as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //            Assert.Equal(fakesource.Products, model,
            //Comparer.Pet<Product>((p1, p2) => p1.Name == p2.Name
            //&& p1.Price == p2.Price));
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(fakeproduct);
            controller.dataSource = mock.Object;
            var model = ((controller.Index()) as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            Assert.Equal(fakeproduct, model,
Comparer.Pet<Product>((p1, p2) => p1.Name == p2.Name
&& p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
