using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class EnterpriseRepository : IRepository<Enterprise>
    {
        private EnterpriseContext _context;

        public EnterpriseRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Enterprise> Entities => _context.Enterprises.ToList();

        public Enterprise GetEntity(int id)
        {
            return _context.Enterprises
                .AsQueryable()
                .FirstOrDefault(enterprise => enterprise.Id == id);
        }

        public async Task<Enterprise> GetEnterpriseTree(int enterpriseId)
        {
            return  await _context.Enterprises.ToListAsync()
                .Include(e => e.Organizations)
                .ThenInclude(o => o.Countries)
                .ThenInclude(c => c.Businesses)
                .ThenInclude(b => b.Families)
                .ThenInclude(f => f.Offerings)
                .ThenInclude(o => o.Departments)
                .ThenInclude(d => d.Users)
                .FirstOrDefault(e => e.Id == enterpriseId);
        }

        public void Create(Enterprise item)
        {
            _context.Enterprises.Add(item);
            _context.SaveChanges();
        }

        public void Update(Enterprise item)
        {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Enterprise enterprise = _context.Enterprises.Find(id);

                _context.Enterprises.Remove(enterprise);
                _context.SaveChanges();
        }
    }
}
