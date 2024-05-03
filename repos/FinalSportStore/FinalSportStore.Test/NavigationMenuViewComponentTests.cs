using FinalSportStore.Components;
using FinalSportStore.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FinalSportStore.Test
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
            new Product {ProductID = 1, Name = "P1", Category = "Apples"},
            new Product {ProductID = 2, Name = "P2", Category = "Apples"},
            new Product {ProductID = 3, Name = "P3", Category = "Plums"},
            new Product {ProductID = 4, Name = "P4", Category = "Oranges"}})
            .AsQueryable<Product>());
            //Act
            NavigationViewComponent Target = new NavigationViewComponent(mock.Object);
            string[] result = ((IEnumerable<string>)(Target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();
            //Assert

            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "plums", "oranges" }, result));
        }
        public void Indicates_Selected_Category()
        {

        }
    }
}
