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

namespace WEB_API_Task_WebApplication.Controllers
{
    [Authorize]
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
        public Enterprise EnterpriseTree(int enterpriseId)
        {
            return _enterpriseRepository.GetEnterpriseTree(enterpriseId);
        }
        
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Enterprise item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating enterprise");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _enterpriseRepository.Create(item);

            return Ok(_enterpriseRepository.Entities);
        }

        [Route("Delete")]
        [HttpPost]
        public List<Enterprise> Delete(int Id)       
        {   
            _enterpriseRepository.Delete(Id);

            return _enterpriseRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Enterprise> Update(Enterprise item) 
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating enterprise");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _enterpriseRepository.Update(item);

            return _enterpriseRepository.Entities;
        }
    }
}
