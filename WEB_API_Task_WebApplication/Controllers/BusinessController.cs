
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
    //[Authorize]
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
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating Business");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_businessRepository.Create(item));
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting business");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _businessRepository.Delete(Id);

            return Ok(_businessRepository.Delete(Id));
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Business item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating Business");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_businessRepository.Update(item));
        }

    }
}
