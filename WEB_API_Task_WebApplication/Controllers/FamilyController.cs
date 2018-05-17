
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

        private readonly FamilyRepository  _familyRepository;
        private readonly ILogger _logger;

        public FamilyController(EnterpriseContext context, ILogger<Family> logger)
        {
            _familyRepository = new FamilyRepository(context);
            _logger = logger;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public List<Family> GetFamilys()
        {
            return _familyRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Family> Create(Family item)
        {
            _familyRepository.Create(item);
            
            return _familyRepository.Entities;
        }

        [Route("Delete")]
        [HttpPost]
        public List<Family> Delete(int Id)
        {
            _familyRepository.Delete(Id);

            return _familyRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Family> Update(Family item) 
        {
            _familyRepository.Update(item);

            return _familyRepository.Entities;
        } 
 
 
    }
}
