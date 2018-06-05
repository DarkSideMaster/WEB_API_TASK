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

            var mockContext = new Mock<EnterpriseContext>();
            mockContext.Setup(context => new EnterpriseContext(new DbContextOptions<EnterpriseContext>()));
            var  controller = new BusinessController(mockContext.Object);
            int expectedBusinessCount = 1;

            // Act
            IActionResult actionResult = controller.GetBuisnesses();
            var okObjectResult = result as OkObjectResult;
           // var presentations = okObjectResult.Value as IEnumerable<Models.Business>;
          
         
            // Assert         
          //   Assert.IsNotNull(presentations);
             Assert.IsNotNull(okObjectResult);
             Assert.IsType<Business>(okObjectResult);
             Assert.Equal(expectedBusinessCount, okObjectResult);           
          // Assert.AreEqual(presentations.Select(g => g.Id).Intersect(gs1Data.Select(d => d.Id)).Count(),
            //  presentations.Count());
                    
            
        }
    }
}
