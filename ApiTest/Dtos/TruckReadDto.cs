using System;
using ApiTest.Models;

namespace ApiTest.Dtos
{
    public class TruckReadDto
    {
        public TruckReadDto()
        {
        }


        public int TruckId { get; set; }

        public string Type { get; set; }
        
        public string PlateInfo { get; set; }

        public string Brand { get; set; }

        public string ModelYear { get; set; }
      
        public string Condition { get; set; }

        
        


    }
}
