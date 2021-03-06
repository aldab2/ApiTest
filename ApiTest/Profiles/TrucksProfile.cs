﻿using System;
using ApiTest.Dtos;
using ApiTest.Models;
using AutoMapper;

namespace ApiTest.Profiles
{
    public class TrucksProfile : Profile
    {
        public TrucksProfile()
        {

            // Source -> Target
            CreateMap<Truck, TruckReadDto>();
            CreateMap<TruckCreateDto, Truck>();
            CreateMap<TruckUpdateDto, Truck>();
            CreateMap<Truck, TruckUpdateDto>(); // This is for the patch

            CreateMap<ServiceProvider, ServiceProviderReadDto>();
            CreateMap<ServiceProviderCreateDto, ServiceProvider>();
            CreateMap<ServiceProviderUpdateDto, ServiceProvider>();
            CreateMap<ServiceProvider, ServiceProviderUpdateDto>(); // This is for the patch


        }
    }
}
