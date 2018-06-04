using System;
using System.Net.Http;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_Task.Controllers;
using Xunit;
using Moq;
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
            mock.Setup(repo=>repo.GetAll()).Returns(GetTestBusiness());
            var controller = new BusinessController(mock.Object);
 
            // Act
            var result = controller.GetBuisnesses();
 
            // Assert
            var businessResult = Assert.IsType<Business>(result);
            var businessassert = Assert.IsAssignableFrom<IEnumerable<Business>>(businessResult.Model);
            Assert.Equal(GetTestBusiness().Count, businessassert.Count());
        }
               
        
        private List<Business> GetTestBusiness()
        {
            var business = new List<Business>
            {
                new Business { Id=1, Name="New Business",   CountryId="342"},
                new Business { Id=2, Name="New Business 2,  CountryId="453"},
                new Business { Id=3, Name="New Business 3", CountryId="778"},
            };
            return business;
        }                                
    }
}
