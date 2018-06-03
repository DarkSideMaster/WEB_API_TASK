using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EnterpriseController : Controller
    {
        private readonly EnterpriseRepository _enterpriseRepository;

        public EnterpriseController(EnterpriseContext context)
        {
            _enterpriseRepository = new EnterpriseRepository(context);
        }
  
        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Enterprises()
        {
            return Ok(_enterpriseRepository.Entities);
        }

        [Route("EnterpriseTree")]
        [HttpGet]
        public async Task<Enterprise> EnterpriseTreeAsync(int enterpriseId)
        {
            return await _enterpriseRepository.GetEnterpriseTreeAsync(enterpriseId);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Enterprise item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_enterpriseRepository.Create(item));
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
                return Ok(_enterpriseRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Enterprise item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_enterpriseRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }
    }
}
