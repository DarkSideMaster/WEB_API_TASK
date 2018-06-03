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
   // [Authorize]
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private readonly OrganizationRepository _organizationRepository;

        public OrganizationController(EnterpriseContext context)
        {
            _organizationRepository = new OrganizationRepository(context);
        }

        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOrganizations()
        {
            return Ok(_organizationRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Organization item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_organizationRepository.Create(item));
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
                return Ok(_organizationRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Organization item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_organizationRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }
    }
}
