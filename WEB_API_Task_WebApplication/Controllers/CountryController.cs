
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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace WEB_API_Task.Controllers
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

        [Route("All")]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_countryRepository.Create(item));
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
                return Ok(_countryRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Country item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_countryRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }

        [Route("Filter")]
        [HttpPost]
        public IActionResult Filter(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                return Ok(_countryRepository.FilterCountry(name));
            }
            catch
            {

                return BadRequest(ModelState); //or can throw new Exception
            }
        }
    }
}
