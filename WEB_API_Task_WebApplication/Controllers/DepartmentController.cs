
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
            if (item == null)
            {
                ModelState.AddModelError("", "No data for creating department");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            return Ok(_departmentRepository.Create(item));
        }

        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (Id < 0)
            {
                ModelState.AddModelError("", "No data for deleting department");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            return Ok(_departmentRepository.Delete(Id));
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult Update(Department item)
        {
            if (item == null)
            {
                ModelState.AddModelError("", "No data for updating department");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_departmentRepository.Update(item));
        }
    }
}
