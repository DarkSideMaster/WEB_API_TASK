using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class OfferingRepository : IRepository<Offering>
    {
        private EnterpriseContext _context;
        private bool _disposed = false;

        public OfferingRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Offering> Entities => _context.Offerings.ToList();

        public Offering GetEntity(int id)
        {
            return _context.Offerings
                .AsQueryable()
                .FirstOrDefault(offering => offering.Id == id);
        }

        public void Create(Offering item)
        {
            _context.Offerings.Add(item);
            _context.SaveChanges();
        }

        public void Update(Offering item)
        {
             _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Offering offering = _context.Offerings.Find(id);
            if (offering != null)
                _context.Offerings.Remove(offering);
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
