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

        public void Create(Family item)
        {
            _context.Familys.Add(item);
            _context.SaveChanges();
        }

        public void Update(Family item)
        {
             if (item!=null)
             {
            _context.Entry(item).State = EntityState.Modified;    
            _context.SaveChanges();
             }
        }

        public void Delete(int id)
        {
            Family family = _context.Familys.Find(id);

            if (family != null)
            {
                _context.Familys.Remove(family);
                _context.SaveChanges();
            }
        }
    }
}
