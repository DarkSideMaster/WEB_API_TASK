using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Database;
using Database.Interfaces;
using Database.Models;
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

            var options = new DbContextOptionsBuilder<EnterpriseContext>().UseInMemoryDatabase("Enterprise").Options;
            var context = new EnterpriseContext(options);
            context.Businesses.Add(new Business{Id = 2, Name = "New Business"});
            var controller = new BusinessController(context);
   
            // Act
            
            IActionResult actionResult = controller.GetBuisnesses();
            var okObjectResult = actionResult as OkObjectResult;
            var valueresult = okObjectResult.Value as IEnumerable<Business>;
           
            // Assert

            Assert.NotNull(valueresult);
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);                              
        }
    }
}
