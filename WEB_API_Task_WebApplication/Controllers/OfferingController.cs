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
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating offering");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _offeringRepository.Create(item);

            return Ok(_offeringRepository.Entities);
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting offering");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _offeringRepository.Delete(Id);

            return Ok(_offeringRepository.Entities);
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Offering item)
        {

            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating offering");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _offeringRepository.Update(item);

            return Ok(_offeringRepository.Entities);
        }
    }
}
