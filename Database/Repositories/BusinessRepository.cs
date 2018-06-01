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

        public Business Create(Business item)
        {
            var createBusinessentity =_context.Businesses.Add(item).Entity;
            _context.SaveChanges();
            return createBusinessentity;
        }

        public Business Update(Business item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return _context.Entry(item).Entity;
        }

        public Business Delete(int id)
        {
            Business business = _context.Businesses.Find(id);

            var deleteBusinessentity = _context.Businesses.Remove(business).Entity;
            _context.SaveChanges();
            return deleteBusinessentity;
        }
    }
}
