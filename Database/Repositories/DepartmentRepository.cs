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
        private bool _disposed = false;

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
        
        if (item!=null)
           {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department != null)
                _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
