using System;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data
{
    public class BarriContext : DbContext
    {
        public BarriContext(DbContextOptions<BarriContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceProvider>()
                .HasMany(sp => sp.Trucks)
                .WithOne(t => t.ServiceProvider);

        }

        



    }

}
