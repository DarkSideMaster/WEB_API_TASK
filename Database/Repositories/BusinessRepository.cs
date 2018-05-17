using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class BusinessRepository : IRepository<Business>
    {
        private EnterpriseContext _context;
        private bool _disposed = false;

        public BusinessRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Business> Entities => _context.Businesses.ToList();

        public Business GetEntity(int id)
        {
            return _context.Businesses
                .AsQueryable()
                .FirstOrDefault(business => business.Id == id);
        }

        public void Create(Business item)
        {
            _context.Businesses.Add(item);
            _context.SaveChanges();
        }

        public void Update(Business item)
        {                   
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Business business = _context.Businesses.Find(id);
            if (business != null)
                _context.Businesses.Remove(business);
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
