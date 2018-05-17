using System.Collections.Generic;
using System.Linq;
using Database.Models;

namespace Database.Extensions
{
    public static class DatabaseExtensions
    {
        public static void EnsureSeedData(this EnterpriseContext context)
        {
            if (context.Enterprises.Any()) return;

            context.Enterprises.Add(new Enterprise
            {
                Name = "Enterprise",
                Organizations = new List<Organization>
                {
                    new Organization
                    {
                        Name = "Organization",
                        Countries = new List<Country>
                        {
                            new Country
                            {
                                Name = "Ukraine",
                                Businesses = new List<Business>
                                {
                                    new Business()
                                    {
                                        Name = "GIS",
                                        Families = new List<Family>
                                        {
                                            new Family
                                            {
                                                Name = "Cloud",
                                                Offerings = new List<Offering>
                                                {
                                                    new Offering
                                                    {
                                                        Name = "Cloud Compute",
                                                        Departments = new List<Department>
                                                        {
                                                            new Department
                                                            {
                                                                Name = "Department C",
                                                                Users = new List<User>
                                                                {
                                                                    new User
                                                                    {
                                                                        Name = "Ivan"
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });

            context.SaveChanges();
        }
    }
}