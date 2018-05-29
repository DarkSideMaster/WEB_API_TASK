using System;
using System.Collections.Generic;
using System.Linq;
using Database.Interfaces;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private EnterpriseContext _context;

        public CountryRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public List<Country> Entities => _context.Сountries.ToList();

        public Country GetEntity(int id)
        {
            return _context.Сountries
                .AsQueryable()
                .FirstOrDefault(country => country.Id == id);
        }

        public void Create(Country item)
        {
            _context.Сountries.Add(item);
            _context.SaveChanges();
        }

        public void Update(Country item)
        {
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Country country = _context.Сountries.Find(id);

            if (country != null)
            {
                _context.Сountries.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}
