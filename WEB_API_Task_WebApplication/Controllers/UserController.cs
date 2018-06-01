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
    //[Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(EnterpriseContext context)
        {
            _userRepository = new UserRepository(context);
        }


        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(User item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating user");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_userRepository.Create(item));
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting user");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_userRepository.Delete(Id));
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(User item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating user");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }         

            return Ok(_userRepository.Update(item));
        }
    }
}
