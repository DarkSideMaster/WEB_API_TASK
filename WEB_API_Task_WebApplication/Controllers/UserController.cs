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
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly ILogger _logger;

        public UserController(EnterpriseContext context, ILogger<User> logger)
        {
            _userRepository = new UserRepository(context);
            _logger = logger;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<User> Create(User item)
        {
            _userRepository.Create(item);

            return _userRepository.Entities;
        }

        [Route("Delete")]
        [HttpPost]
        public List<User> Delete(int Id)
        {
            _userRepository.Delete(Id);

            return _userRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<User> Update(User item) 
        {
            _userRepository.Update(item);

            return _userRepository.Entities;
        }
    }
}
