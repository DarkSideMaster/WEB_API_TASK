
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
    public class FamilyController : Controller
    {
        private readonly FamilyRepository _familyRepository;

        public FamilyController(EnterpriseContext context)
        {
            _familyRepository = new FamilyRepository(context);
        }

        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetFamilys()
        {
            return Ok(_familyRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Family item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_familyRepository.Create(item));
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
                return Ok(_familyRepository.Delete(Id)); //or you can throw new Exception
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Family item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_familyRepository.Update(item)); //or you can throw new Exception
            }
            catch
            {
                return BadRequest(ModelState);
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

            var familyfilter = _familyRepository.Filter(name);

            if (familyfilter == null)
            {
                return Content("The family is not found!");
            }

            try
            {    
                return Ok(familyfilter);
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }   
        }                              
    }
}
