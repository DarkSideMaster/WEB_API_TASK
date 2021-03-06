﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Enterprise> GetEnterpriseTreeAsync(int enterpriseId)
        {
            return await _context.Enterprises
                .Include(e => e.Organizations)
                .ThenInclude(o => o.Countries)
                .ThenInclude(c => c.Businesses)
                .ThenInclude(b => b.Families)
                .ThenInclude(f => f.Offerings)
                .ThenInclude(o => o.Departments)
                .ThenInclude(d => d.Users)
                .FirstOrDefaultAsync(e => e.Id == enterpriseId);
        }

        public Enterprise Create(Enterprise item)
        {
            var createEnterprisesentity = _context.Enterprises.Add(item).Entity;

            _context.SaveChanges();
            return createEnterprisesentity;
        }

        public Enterprise Update(Enterprise item)
        {
            _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
            return _context.Entry(item).Entity;
        }

        public Enterprise Delete(int id)
        {
            Enterprise enterprise = _context.Enterprises.Find(id);

            var deleteEnterprisesentity = _context.Enterprises.Remove(enterprise).Entity;
            _context.SaveChanges();
            return deleteEnterprisesentity;
        }
        
         public Enterprise Filter(string name)
        {
            return _context.Enterprises.FirstOrDefault(enterprise => enterprise.Name == name);
        }             
    }
}
