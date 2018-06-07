
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
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(EnterpriseContext context)
        {
            _departmentRepository = new DepartmentRepository(context);
        }

        [Route("All")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentRepository.Entities);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Department item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_departmentRepository.Create(item));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
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
                return Ok(_departmentRepository.Delete(Id));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Department item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_departmentRepository.Update(item));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }
        }
        
        [Route("Filter")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Filter(string name)
        {              
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {  
            var department = new Department();
            
            if (department.Name != name)
            {
                return Content("Error");
            }         
                return Ok(_departmentRepository.FilterDepartment(name));
            }
            catch
            {
                return BadRequest(ModelState); //or can throw new Exception
            }   
        }         
    }
}
