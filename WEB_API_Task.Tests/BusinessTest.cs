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

            var actionResult = controller.GetBuisnesses();

            // Assert

            //Assert.NotNull(result);
            //Assert.IsType<Business>(result);
            //Assert.Equal(expectedBusinessCount,result);
        }


    }
}
