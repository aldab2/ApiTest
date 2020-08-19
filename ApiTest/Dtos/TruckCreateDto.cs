using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTest.Dtos
{
    public class TruckCreateDto
    {
        public TruckCreateDto()
        {
        }

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
    }
}
