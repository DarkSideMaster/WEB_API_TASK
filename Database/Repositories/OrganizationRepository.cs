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

        public Organization Create(Organization item)
        {
            var createOrganizationentity = _context.Organizations.Add(item).Entity;
            _context.SaveChanges();
            return createOrganizationentity;
        }

        public Organization Update(Organization item)
        {
            var updateOrganizationentity = _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return updateOrganizationentity;
        }

        public Organization Delete(int id)
        {
            Organization organization = _context.Organizations.Find(id);

            var deleteOrganizationentity = _context.Organizations.Remove(organization).Entity;
            _context.SaveChanges();
            return deleteOrganizationentity;
        }
    }
}
