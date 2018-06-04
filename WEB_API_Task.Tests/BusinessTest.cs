using System;
using System.Net.Http;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_Task.Controllers;
using Xunit;
using Newtonsoft.Json.Linq;

namespace WEB_API_Task.Tests
{
    public class BusinessTest
    {

        [Fact]
        public void GetBusinessReturnsListOfBusiness()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo=>repo.GetAll()).Returns(GetTestPhones());
            var controller = new HomeController(mock.Object);
 
            // Act
            var result = controller.Index();
 
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Phone>>(viewResult.Model);
            Assert.Equal(GetTestPhones().Count, model.Count());
        }
        
        
        
        private List<Phone> GetTestPhones()
        {
            var phones = new List<Phone>
            {
                new Phone { Id=1, Name="iPhone 7", Company="Apple", Price=900},
                new Phone { Id=2, Name="Meizu 6 Pro", Company="Meizu", Price=300},
                new Phone { Id=3, Name="Mi 5S", Company="Xiaomi", Price=400},
                new Phone { Id=4, Name="iPhone 7", Company="Apple", Price=900},
            };
            return phones;
        }
                        
        
    }
}
