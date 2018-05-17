
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
    public class BusinessController : Controller
    {
        private readonly BusinessRepository _businessRepository;
        private readonly ILogger _logger;

        public BusinessController(EnterpriseContext context, ILogger<Business> logger)
        {
            _businessRepository = new BusinessRepository(context);
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public List<Business> GetBuisnesses()
        {
            return _businessRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Business> Create(Business item)
        {
            _businessRepository.Create(item);

            return _businessRepository.Entities;
        }
        
        [Route("Delete")]
        [HttpPost]
        public List<Business> Delete(int Id)
        {
            _businessRepository.Delete(Id);

            return _businessRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Business> Update(Business item) 
        {
            _businessRepository.Update(item);

            return _businessRepository.Entities;
        }
                
    }
}
