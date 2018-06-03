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

namespace WEB_API_Task.Controllers
{
    [Authorize]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_userRepository.Create(item));
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
                return Ok(_userRepository.Delete(Id));
            }

            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(User item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_userRepository.Update(item));
            }

            catch
            {
                return BadRequest(ModelState); //or you can throw new Exception
            }
        }
    }
}
