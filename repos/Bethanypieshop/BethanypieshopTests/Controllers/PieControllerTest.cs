using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bethanypieshop.Controllers;
using Bethanypieshop.ViewModels;
using BethanypieshopTests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace BethanypieshopTests.Controllers
{

    
    public class PieControllerTest
    {
        [Fact]
        public void List_EmptyCategory_ReturnAllPies()
        {
            //arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCateRepository=RepositoryMocks.GetCategoryRepository();
            var picontroller = new PieController(mockPieRepository.Object, mockCateRepository.Object);
            //act
            var Result = picontroller.List("");
            //assert

            var viewResult = Assert.IsType<ViewResult>(Result);
            //var p = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            //Assert.Equal(10, p.Pies.Count());               


        }
        

     
        
    }
}
