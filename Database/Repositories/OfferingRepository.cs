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

        public Offering Create(Offering item)
        {
            var entity =  _context.Offerings.Add(item).Entity;          
            _context.SaveChanges();
            return entity;
        }

        public Offering Update(Offering item)
        {
               var entity = _context.Entry(item).State = EntityState.Modified;
               _context.SaveChanges();
                return entity;
        }

        public Offering Delete(int id)
        {
            Offering offering = _context.Offerings.Find(id);

            var entity = _context.Offerings.Remove(offering).Entity;
            _context.SaveChanges();

            return entity;
        }
    }
}
