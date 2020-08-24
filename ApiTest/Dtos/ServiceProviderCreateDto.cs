using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApiTest.Models;

namespace ApiTest.Dtos
{
    public class ServiceProviderCreateDto
    {
        public ServiceProviderCreateDto()
        {
        }

        public int SPId { get; set; }


        [Required]
        public string CrNumber { get; set; } // Commercial Record
        [Required]
        public DateTime CrExpireDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyRepresenterName { get; set; }
        [Required]
        public string RepresenterMobile { get; set; }
        [Required]
        public string CompanyTelephone { get; set; }
        [Required]
        public string InsurancePolicy { get; set; }



        public ICollection<Truck> Trucks { get; set; }
    }
}
