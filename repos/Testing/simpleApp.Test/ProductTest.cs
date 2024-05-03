using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace simpleApp.Test
{
    public class ProductTest
    {
        [Fact]
       public void CanChangeName()
        {
            //Arrange
            Product p = new Product { Name = "thea", Price = 300 };
            //Act
            p.Name = "sandhya";
            //Assert
            Assert.Equal("sandhya",p.Name);
        }
        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            Product p = new Product { Name = "vaidehi", Price = 400 };
            //Act
            p.Price = 560;
            //Assert
            Assert.Equal(560, p.Price);


        }
    }
}
