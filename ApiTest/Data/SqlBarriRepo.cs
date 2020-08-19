using System;
using System.Collections.Generic;
using System.Linq;
using ApiTest.Models;

namespace ApiTest.Data
{
    public class SqlBarriRepo : IBarriRepo
    {
        private readonly BarriContext _context;

        public SqlBarriRepo(BarriContext context)
        {
            _context = context;
        }

        public void DeleteTruck(Truck truck)

        {
            if(truck == null)
            {
                throw new ArgumentNullException();
            }

            _context.Remove(truck);
        }

        public IEnumerable<Truck> GetAllTrucks()
        {
            var trucks = _context.Trucks.ToList();

            return trucks;
        }

        public Truck GetTruckById(int TruckId)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == TruckId);

            return truck;

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

        public void UpdateTruck(Truck truck)
        {
           // Nothing
        }
    }
}
