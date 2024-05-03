using Bethanypieshop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanypieshopTests.Mocks
{

    public static class RepositoryMocks
    {
        public static Mock<IPieRepository> GetPieRepository()
        {
            var pies = new List<Pie>
            {
                new Pie
                {
                    Name = "Strawberry Pie",
                    Price = 15.95M,
                    ShortDescription = "Our delicious strawberry pie!",
                    LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan toffee brownie brownie candy tootsie roll. Chocolate cake.",
                    Catigory = Categories["Fruit pies"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                    InStock = true,
                    IsPieOfTheWeek = false,
                    ImageThumbnailUrl ="https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                    AllergyInformation = ""
                },
                new Pie
                {
                    Name =  "Cheese Pie",
                    Price = 15.95M,
                    ShortDescription = "Our delicious strawberry pie!",
                    LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan toffee brownie brownie candy tootsie roll. Chocolate cake.",
                    Catigory = Categories["Fruit pies"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                    InStock = true,
                    IsPieOfTheWeek = false,
                    ImageThumbnailUrl ="https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                    AllergyInformation = ""
                },
                new Pie
                {
                    Name = "Strawberry Pie",
                    Price = 15.95M,
                    ShortDescription = "Our delicious strawberry pie!",
                    LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan toffee brownie brownie candy tootsie roll. Chocolate cake.",
                    Catigory = Categories["Fruit pies"],
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                    InStock = true,
                    IsPieOfTheWeek = false,
                    ImageThumbnailUrl ="https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                    AllergyInformation = ""
                }



            };
            var mockPieRepository= new Mock<IPieRepository>();
            mockPieRepository.Setup(repo => repo.AllPies).Returns(pies);
            mockPieRepository.Setup(repo => repo.PiesOfTheWeek).Returns(pies.Where(p => p.IsPieOfTheWeek));
            mockPieRepository.Setup(repo => repo.GetPieById(It.IsAny<int>())).Returns(pies[0]);
            return mockPieRepository;

        }
        public static Mock<ICatigoryRepository> GetCategoryRepository()
        {
            var Categories = new List<Catigory>
            {
                new Catigory()
                {
                    CatigoryId = 1,
                    CatigoryName = "Fruit pies",
                    Description = "Lorem ipsum"
                },
                new Catigory()
                {
                    CatigoryId = 2,
                    CatigoryName = "Cheese cakes",
                    Description = "Lorem ipsum"
                },
                new Catigory()
                {
                    CatigoryId = 3,
                    CatigoryName = "Fruit",
                    Description = "Seasonal pies"
                }
            };
            var mockCatigoryRepository=new Mock<ICatigoryRepository>();
            mockCatigoryRepository.Setup(repo => repo.AllCatigories).Returns(Categories);
            return mockCatigoryRepository;


        }
       private static Dictionary<string, Catigory>? _Categories;
        public static Dictionary<string, Catigory> Categories
        {
            get
            {
                if (_Categories == null)
                {
                    var cat = new Catigory[]
                    {
                        new Catigory{CatigoryName="Fruit pies"},
                        new Catigory{CatigoryName="Cheese Pies"},
                        new Catigory{CatigoryName="Seasonal Pies"}
                    };
                    _Categories = new Dictionary<string, Catigory>();
                    foreach (var x in cat)
                    {
                        _Categories.Add(x.CatigoryName, x);
                    }

                }
                return _Categories;
            }



        }
    }
}
