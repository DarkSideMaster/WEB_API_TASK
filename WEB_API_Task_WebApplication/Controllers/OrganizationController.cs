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
        private readonly ILogger _logger;

        public OrganizationController(EnterpriseContext context, ILogger<Organization> logger)
        {
            _organizationRepository = new OrganizationRepository(context);
            _logger = logger;
        }

       [AllowAnonymous]
        [HttpGet]
        public List<Organization> GetOrganizations()
        {
            return _organizationRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Organization> Create(Organization item)
        {
            _organizationRepository.Create(item);

            return _organizationRepository.Entities;
        }

        [Route("Delete")]
        [HttpPost]
        public List<Organization> Delete(int Id)
        {
            _organizationRepository.Delete(Id);

            return _organizationRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Organization> Update(Organization item) 
        {
           _organizationRepository.Update(item);

            return _organizationRepository.Entities;
        }
    }
}
