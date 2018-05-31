
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
    public class CountryController : Controller
    {
        private readonly CountryRepository _countryRepository;

        public CountryController(EnterpriseContext context)
        {
            _countryRepository = new CountryRepository(context);
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetCountryses()
        {
            return Ok(_countryRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Country item)
        {
        
            if (item == null)
            {
                ModelState.AddModelError("", "No data for add country");
                return BadRequest(ModelState);
            }
        
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
             }
               
            _countryRepository.Create(item);

            return Ok(_countryRepository.Entities);
        }
        
        [Route("Delete")]
        [HttpPost]
        public List<Country>Delete(int Id)
        {            
            _countryRepository.Delete(Id);

            return _countryRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Country item) 
        {       
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating country");
                return BadRequest(ModelState);
            }
        
            if (!ModelState.IsValid)
             {
                return BadRequest(ModelState);
             }
            
            _countryRepository.Update(item);

            return Ok(_countryRepository.Entities);
        }                   
   }
}
