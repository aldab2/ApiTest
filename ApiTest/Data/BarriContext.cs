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



    }
}
