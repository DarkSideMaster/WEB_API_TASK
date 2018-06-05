using Database.Extensions;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public sealed class EnterpriseContext : DbContext
    {
        public EnterpriseContext(DbContextOptions<EnterpriseContext> options) 
            : base(options)
        {

        }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Family> Familys { get; set; }
        public DbSet<Country> Сountries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
                 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<Department>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<Family>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<Organization>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<Enterprise>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<Offering>()
                .HasIndex(c => c.Id)
                .IsUnique();
                 modelBuilder.Entity<Business>()
                .HasIndex(c => c.Id)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(c => c.Id)
                .IsUnique();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseInMemoryDatabase();
        //    }
        //}
    }
}
