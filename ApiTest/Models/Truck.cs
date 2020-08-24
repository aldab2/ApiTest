using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTest.Models
{
    public class Truck
    {
        public Truck()
        {
        }

        [Key]
        public int TruckId { get; set; }

        [Required]
        public string Type { get; set; }
        [Required]
        public string PlateInfo { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string ModelYear { get; set; }
        [Required]
        public string Condition { get; set; }


        
        public ServiceProvider ServiceProvider { get; set; }



    }
}
