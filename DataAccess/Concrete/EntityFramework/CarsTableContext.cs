using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class CarsTableContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarTables;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
