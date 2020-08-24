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

        IEnumerable<ServiceProvider> GetAllServiceProviders();
        ServiceProvider GetServiceProviderById(int SPId);
        void PostServiceProvider(ServiceProvider sp);
        void UpdateServiceProvider(ServiceProvider sp);
        void DeleteServiceProvider(ServiceProvider sp);



        void SeedDatabase();


    }
}
