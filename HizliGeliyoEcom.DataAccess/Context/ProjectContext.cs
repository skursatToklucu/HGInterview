using HizliGeliyoEcom.Entities.Entities;
using HizliGeliyoEcom.Entities.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Context
{
    public class ProjectContext : DbContext
    {

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
