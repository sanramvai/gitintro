using FinalLessons.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FinalLesson.Test
{
   public class ProductTests
    {
        [Fact]

        
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };
            //Act
            p.Name = "New Name";
            //Assert
            Assert.Equal("New Name", p.Name);

        }
        [Fact]
         public void CanChangeProductPrice()
        {
            //Arrange
            var p=new Product { Name = "Test", Price = 100M };
            //Act
            p.Price = 200;
            //Assert
            Assert.Equal(200, p.Price);

        }
}
}
