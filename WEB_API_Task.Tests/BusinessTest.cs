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
        public void Business_Get_All()
        {
            // var controller = new BusinessController(new EnterpriseContext(new DbContextOptions<EnterpriseContext>()));  
            //   var result = controller.GetBuisnesses();     

            //var responseString = response.Content.ReadAsString().Result;

            //dynamic jsonObject = JObject.Parse(responseString);
            //int Id = (int)jsonObject.Id;
            //Assert.Equal(1, Id);
        }
        
        [Fact]
        public void GetAllBusinessReturnsEverythingInRepository()
        {
            
          // Arrange
           var allBusiness = new[] 
            {
                new Business { Id=2, Name="New Business", CountryId="234"},
                new Business { Id=3, Name="New Business2", CountryId="453}
            };
        
           var repo = new BusinessRepository
           {
             GetAll = () => allBusiness
           };
        
          var controller = new BusinessController(repo);

         // Act
         var result = controller.GetBuisnesses();

         // Assert
         Assert.Same(allBusiness, result);
     }
                        
        }
    }
}
