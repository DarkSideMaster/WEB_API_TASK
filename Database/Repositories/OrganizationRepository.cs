using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class OrganizationRepository : IRepository<Organization>
    {
        private EnterpriseContext _context;
        private bool _disposed = false;

        public OrganizationRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Organization> Entities => _context.Organizations.ToList();

        public Organization GetEntity(int id)
        {
            return _context.Organizations
                .AsQueryable()
                .FirstOrDefault(organization => organization.Id == id);
        }

        public void Create(Organization item)
        {
            _context.Organizations.Add(item);
            _context.SaveChanges();
        }

        public void Update(Organization item)
        {
             _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Organization organization = _context.Organizations.Find(id);
            if (organization != null)
                _context.Organizations.Remove(organization);
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
