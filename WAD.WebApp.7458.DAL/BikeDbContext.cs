using Microsoft.EntityFrameworkCore;
using System;
using WAD.WebApp._7458.DAL.DBO;

namespace WAD.WebApp._7458.DAL
{
    public class BikeDbContext : DbContext
    {
        public BikeDbContext()
        {

        }
        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options)
        {
 
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
         //=> options.UseSqlServer("DataSource=BikeStore.db");

        public virtual DbSet<Bike> Bike { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }

        public virtual DbSet<Category> Category { get; set; }
    }
}
