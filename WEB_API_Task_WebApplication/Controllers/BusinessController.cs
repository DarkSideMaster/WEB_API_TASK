
using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WEB_API_Task_WebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BusinessController : Controller
    {
        private readonly BusinessRepository _businessRepository;

        public BusinessController(EnterpriseContext context)
        {
            _businessRepository = new BusinessRepository(context);
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Business> GetBuisnesses()
        {
            return _businessRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Business> Create(Business item)
        {      
            //if (item == null)
            //{
            //    ModelState.AddModelError("", "No data for creating Business");
            //    return BadRequest(ModelState);
            //}
        
            // if (!ModelState.IsValid)
            // {
            //    return BadRequest(ModelState);
            // }
             
            _businessRepository.Create(item);

            return _businessRepository.Entities;
        }
        
        [Route("Delete")]
        [HttpPost]
        public List<Business> Delete(int Id)
        {            
   
            _businessRepository.Delete(Id);

            return _businessRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Business> Update(Business item) 
        {     
            //if (item == null)
            //{
            //    ModelState.AddModelError("", "No data for updating Business");
            //    return BadRequest(ModelState);
            //}
        
            // if (!ModelState.IsValid)
            // {
            //    return BadRequest(ModelState);
            // }
                
            _businessRepository.Update(item);

            return _businessRepository.Entities;
        }
                
    }
}
