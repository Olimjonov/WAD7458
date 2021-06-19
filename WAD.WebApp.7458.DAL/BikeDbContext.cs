using Microsoft.EntityFrameworkCore;
using System;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.DAL
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Bike> Bike { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }

        public virtual DbSet<Category> Category { get; set; }
    }
}
