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
        private readonly ILogger _logger;

        public OfferingController(EnterpriseContext context, ILogger<Offering> logger)
        {
            _offeringRepository = new OfferingRepository(context);
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Offering> GetOfferings()
        {
            return _offeringRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Offering> Create(Offering item)
        {
            _offeringRepository.Create(item);

            return _offeringRepository.Entities;
        }

        [Route("Delete")]
        [HttpPost]
        public List<Offering> Delete(int Id)
        {
            _offeringRepository.Delete(Id);

            return _offeringRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Offering> Update(Offering item) 
        {
            _offeringRepository.Update(item);

            return _offeringRepository.Entities;
        }   
      
    }
}
