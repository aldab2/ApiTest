using System;
using System.Collections.Generic;
using ApiTest.Models;

namespace ApiTest.Data
{
    public class MockBarriRepo : IBarriRepo
    {
        private List<Truck> _data;

        public MockBarriRepo()
        {
            _data = new List<Truck>()
        {
            new Truck{ TruckId = 0, PlateInfo = "4251 DAE" , Brand= "Toshiba" , ModelYear = "2018" , Type = "DS2" , Condition = "Good"},
            new Truck{ TruckId = 1, PlateInfo = "3452 ASD" , Brand= "Toshiba" , ModelYear = "2012" , Type = "S4" , Condition = "Average"},
            new Truck{ TruckId = 2, PlateInfo = "6745 JKU" , Brand= "Toshiba" , ModelYear = "2019" , Type = "DA1", Condition = "Very Good"},
            new Truck{ TruckId = 3, PlateInfo = "9543 MFR" , Brand= "Toshiba" , ModelYear = "2015" , Type = "MM3", Condition = "Good"},

        };
        }

        public void DeleteTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Truck> GetAllTrucks()
        {

            return _data;
        }

        public Truck GetTruckById(int TruckId)
        {
            return _data.Find(t => t.TruckId == TruckId);
        }

        public void PostTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTruck(Truck truck)
        {
            throw new NotImplementedException();
        }
    }
}
