using FinalSportStore.Controllers;
using FinalSportStore.Models;
using FinalSportStore.Models.ViewModel;
using FinalSportStore.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FinalSportStore.Test
{
    public class HomeControllerTest
    {
        [Fact]
       public void Can_Send_Pagination_ViewModel()
        {
            
            
        }
        [Fact]
        public void Can_Use_Repository()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
            new Product {ProductID = 1, Name = "P1"},
            new Product {ProductID = 2, Name = "P2"},
            new Product {ProductID = 3, Name = "P3"},
            new Product {ProductID = 4, Name = "P4"},
            new Product {ProductID = 5, Name = "P5"} }
            ).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object) { ProdPerPage = 3 };
            // Act
            ProductListViewModel result =
            (controller.Index(null,2)as ViewResult).ViewData.Model as ProductListViewModel;
            // Assert
            PageInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ProductPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);

        }
        [Fact]
        public void Can_Paginate()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m=>m.Products).Returns((new Product[] {
            new Product {ProductID = 1, Name = "P1"},
            new Product {ProductID = 2, Name = "P2"},
            new Product {ProductID = 3, Name = "P3"},
            new Product {ProductID = 4, Name = "P4"},
            new Product {ProductID = 5, Name = "P5"} }
            ).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            controller.ProdPerPage = 3;
            ProductListViewModel result = (controller.Index(null,2) as ViewResult).ViewData.Model as ProductListViewModel;
            Product[] prodArray = result.Products.ToArray();
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);

        }
        [Fact]
        public void can_Filter_Products()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
            new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
            new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
            new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
            new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
            new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);
            controller.ProdPerPage = 3;
            ProductListViewModel result= (controller.Index("Cat1", 1) as ViewResult).ViewData.Model as ProductListViewModel;
            Product[] prodArray = result.Products.ToArray();

            Assert.Equal(2, prodArray.Length);
            Assert.True((prodArray[0].ProductID == 1) && (prodArray[0].Category == "Cat1"));
            Assert.True((prodArray[1].ProductID == 3) && (prodArray[1].Category == "Cat1"));


        }
    }
}
