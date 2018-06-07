
using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WEB_API_Task.Controllers
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

        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetBuisnesses()
        {
            return Ok(_businessRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Business item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_businessRepository.Create(item));
            }
            catch 
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_businessRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Business item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_businessRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }
        
        [Route("Filter")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Filter(string name)
        {       
        var business = new Business();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {                
            if (business.Name != name)
            {
                return Content("Error");
            }         
                return Ok(_businessRepository.FilterBusiness(name));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }   
        }
    }
}
