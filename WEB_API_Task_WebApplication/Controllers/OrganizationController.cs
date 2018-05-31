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
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating organization");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _organizationRepository.Create(item);

            return Ok(_organizationRepository.Entities);
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {

            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting organization");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _organizationRepository.Delete(Id);

            return Ok(_organizationRepository.Entities);
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Organization item)
        {

            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating organization");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _organizationRepository.Update(item);

            return Ok(_organizationRepository.Entities);
        }
    }
}
