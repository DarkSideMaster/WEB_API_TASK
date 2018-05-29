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

        public void Create(Business item)
        {
            _context.Businesses.Add(item);
            _context.SaveChanges();
        }

        public void Update(Business item)
        {
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Business business = _context.Businesses.Find(id);
            if (business != null)
            {
                _context.Businesses.Remove(business);
                _context.SaveChanges();
            }
        }
    }
}
