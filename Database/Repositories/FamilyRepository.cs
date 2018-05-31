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

        public Family Create(Family item)
        {
            var entity = _context.Familys.Add(item).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Family Update(Family item)
        {
            var entity = _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
            return entity;
        }

        public Family Delete(int id)
        {
            Family family = _context.Familys.Find(id);

            var entity = _context.Familys.Remove(family).Entity;
            _context.SaveChanges();
            return entity;
        }
    }
}
