﻿using Karma.Entities;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class KarmaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=KarmaDb;Integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}