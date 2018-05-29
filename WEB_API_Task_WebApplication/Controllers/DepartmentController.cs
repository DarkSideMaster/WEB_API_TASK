
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
        
        [AllowAnonymous]
        [HttpGet]
        public List<Department> GetDepartments()
        {
            return _departmentRepository.Entities;
        }

        [Route("Create")]
        [HttpPost]
        public List<Department> Create(Department item)
        {
            _departmentRepository.Create(item);

            return _departmentRepository.Entities;
        }
        
        [Route("Delete")]
        [HttpPost]
        public List<Department> Delete(int Id)
        {
            _departmentRepository.Delete(Id);

            return _departmentRepository.Entities;
        }
        
        [Route("Update")]
        [HttpPost]
        public List<Department> Update(Department item) 
        {
            _departmentRepository.Update(item);

            return _departmentRepository.Entities;
        }                     
    }
}
