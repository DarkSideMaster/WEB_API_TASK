using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private EnterpriseContext _context;

        public DepartmentRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Department> Entities => _context.Departments.ToList();

        public Department GetEntity(int id)
        {
            return _context.Departments
                .AsQueryable()
                .FirstOrDefault(department => department.Id == id);
        }

        public void Create(Department item)
        {
            _context.Departments.Add(item);
            _context.SaveChanges();
        }

        public void Update(Department item)
        {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Department department = _context.Departments.Find(id);

                _context.Departments.Remove(department);
                _context.SaveChanges();
        }
    }
}
