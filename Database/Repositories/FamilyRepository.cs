using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class FamilyRepository : IRepository<Family>
    {
        private EnterpriseContext _context;
        private bool _disposed = false;

        public FamilyRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Family> Entities => _context.Familys.ToList();

        public Family GetEntity(int id)
        {
            return _context.Familys
                .AsQueryable()
                .FirstOrDefault(family => family.Id == id);
        }

        public void Create(Family item)
        {
            _context.Familys.Add(item);
            _context.SaveChanges();
        }

        public void Update(Family item)
        {
             _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Family family = _context.Familys.Find(id);
            if (family != null)
                _context.Familys.Remove(family);
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
