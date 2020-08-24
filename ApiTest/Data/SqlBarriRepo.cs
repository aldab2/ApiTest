using System;
using System.Collections.Generic;
using System.Linq;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data
{
    public class SqlBarriRepo : IBarriRepo
    {
        private readonly BarriContext _context;

        public SqlBarriRepo(BarriContext context)
        {
            _context = context;
        }

        public void DeleteServiceProvider(ServiceProvider sp)
        {
            if (sp == null)
            {
                throw new ArgumentNullException();
            }

            _context.Remove(sp);
        }

        public void DeleteTruck(Truck truck)

        {
            if(truck == null)
            {
                throw new ArgumentNullException();
            }

            _context.Remove(truck);
        }

        public IEnumerable<ServiceProvider> GetAllServiceProviders()
        {
            var trucks = _context.ServiceProviders.Include(sp => sp.Trucks
            ).ToList();

            return trucks;
        }

        public IEnumerable<Truck> GetAllTrucks()
        {
            var Sps = _context.Trucks.Include(t => t.ServiceProvider).ToList();

            return Sps;
        }

        public ServiceProvider GetServiceProviderById(int SPId)
        {
            var sp = _context.ServiceProviders.Include(sp => sp.Trucks).FirstOrDefault(sp => sp.SPId == SPId);
           

            return sp;
        }

        public Truck GetTruckById(int TruckId)
        {
            var truck = _context.Trucks.Include(t => t.ServiceProvider).FirstOrDefault(t => t.TruckId == TruckId);

            return truck;

        }

        public void PostServiceProvider(ServiceProvider sp)
        {
            if (sp == null)
            {
                throw new ArgumentNullException();

            }
            _context.ServiceProviders.Add(sp);
        }

        public void PostTruck(Truck truck)
        {
            if(truck == null)
            {
                throw new ArgumentNullException();

            }
            _context.Trucks.Add(truck);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0 ;
        }

        public void SeedDatabase()
        {
            DbInitializer.Initialize(_context);
        }

        public void UpdateServiceProvider(ServiceProvider sp)
        {
            // Nothing
        }

        public void UpdateTruck(Truck truck)
        {
           // Nothing
        }
    }
}
