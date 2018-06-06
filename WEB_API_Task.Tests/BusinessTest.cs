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

            var options = new DbContextOptionsBilder<EnterpriseContext>().UseinMemoryDatabase("Enterprise").Options;
            var context = new EnterpriseContext(options);
            context.Business.Add(new Business{Name = "New Business"});
            var controller = new BusinessController(context);
            int expectedBusinessCount = 1;

            // Act
            IActionResult actionResult = controller.GetBusiness();
            var okObjectResult = actionResult as OkobjectResult;
            var valueresult = okObjectResult.Value as IEnumerable<Business>;
          
         
            // Assert
            
              Assert.IsNotNull(valueresult);
              Assert.IsNotNull(okObjectResult);
              Assert.IsType<Business>(okObjectResult);
           // Assert.Equal(expectedBusinessCount, okObjectResult);           
          //  Assert.AreEqual(presentations.Select(g => g.Id).Intersect(gs1Data.Select(d => d.Id)).Count(),
          //  presentations.Count());
                    
            
        }
    }
}
