
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
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating family");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_familyRepository.Create(item));
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {

            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting family");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_familyRepository.Delete(Id));
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Family item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating family");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_familyRepository.Update(item));

        }
    }
}
