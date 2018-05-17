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
        private readonly ILogger _logger;

        public EnterpriseController(EnterpriseContext context, ILogger<Enterprise> logger)
        {
            _enterpriseRepository = new EnterpriseRepository(context);
            _logger = logger;
        }
        
        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public List<Enterprise> Enterprises()
        {
            return _enterpriseRepository.Entities;
        }

        [Route("EnterpriseTree")]
        [HttpGet]
        public Enterprise EnterpriseTree(int enterpriseId)
        {
            return _enterpriseRepository.GetEnterpriseTree(enterpriseId);
        }
        
        [Route("Create")]
        [HttpPost]
        public List<Enterprise> Create(Enterprise item)
        {
            _enterpriseRepository.Create(item);

            return _enterpriseRepository.Entities;
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
            _enterpriseRepository.Update(item);

            return _enterpriseRepository.Entities;
        }
    }
}
