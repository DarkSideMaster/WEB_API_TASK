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
    public class OfferingController : Controller
    {
        private readonly OfferingRepository _offeringRepository;

        public OfferingController(EnterpriseContext context)
        {
            _offeringRepository = new OfferingRepository(context);
        }

        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOfferings()
        {
            return Ok(_offeringRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Offering item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_offeringRepository.Create(item));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
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
                return Ok(_offeringRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Offering item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_offeringRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }
        
        [Route("Filter")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Filter(string name)
        {              
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {  
            
            var offering = new Offering();
            
            if (offering.Name != name)
            {
                return Content("Error");
            }         
                return Ok(_offeringRepository.FilterOffering(name));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }   
        }                                       
    }
}
