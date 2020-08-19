using System;
using System.Collections.Generic;
using ApiTest.Models;

namespace ApiTest.Data
{
    public interface IBarriRepo
    {
        bool SaveChanges();

        Truck GetTruckById(int TruckId);
        IEnumerable<Truck> GetAllTrucks();
        void PostTruck(Truck truck);
        void UpdateTruck(Truck truck);
        void DeleteTruck(Truck truck);


    }
}
