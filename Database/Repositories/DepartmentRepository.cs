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

        public Department Create(Department item)
        {
            var entity = _context.Departments.Add(item).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Department Update(Department item)
        {
           var entity = _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public Department Delete(int id)
        {
            Department department = _context.Departments.Find(id);

            var entity = _context.Departments.Remove(department).Entity;
            _context.SaveChanges();
            return entity;
        }
    }
}
