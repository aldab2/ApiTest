using System;
using System.Collections.Generic;
using ApiTest.Data;
using ApiTest.Dtos;
using ApiTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/service_provider")]
    [ApiController]
    public class ServiceProvidersController : ControllerBase
    {
       
        private readonly IBarriRepo _repository;

        private readonly IMapper _mapper;

        public ServiceProvidersController(IBarriRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/service_provider/
        [HttpGet]
        public ActionResult<IEnumerable<ServiceProvider>> GetAllServiceProviders()
        {
            var SPs = _repository.GetAllServiceProviders();

            if (SPs == null)
            {
                return NotFound();
            }

            var SPsReadDto = _mapper.Map<IEnumerable<ServiceProviderReadDto>>(SPs);

            return Ok(SPsReadDto);
        }


        // GET api/service_provider/{id}
        [HttpGet("{id}", Name = "GetServiceProviderById")]
        public ActionResult<Truck> GetServiceProviderById(int id)
        {
            var sp = _repository.GetServiceProviderById(id);

            if (sp == null)
            {
                return NotFound();
            }
            var serviceProviderReadDto = _mapper.Map<ServiceProviderReadDto>(sp);

            return Ok(serviceProviderReadDto);
        }

        // POST api/service_provider/
        [HttpPost]
        public ActionResult<ServiceProvider> PostServiceProvider(ServiceProviderCreateDto serviceProviderCreateDto)
        {
            var SPModel = _mapper.Map<ServiceProvider>(serviceProviderCreateDto);
            _repository.PostServiceProvider(SPModel);
            _repository.SaveChanges();

            var serviceProviderReadDto = _mapper.Map<ServiceProviderReadDto>(SPModel);

            return CreatedAtRoute(nameof(GetServiceProviderById), new { Id = serviceProviderReadDto.SPId }, serviceProviderReadDto);

        }


        // PUT api/service_provider/{id}
        [HttpPut("{id}")]
        public ActionResult<ServiceProvider> UpdateServiceProvider(int id, ServiceProviderUpdateDto serviceProviderUpdateDto)
        {
            var SPModel = _repository.GetServiceProviderById(id);
            if(SPModel == null)
            {
                return NotFound();
            }

            _mapper.Map(serviceProviderUpdateDto, SPModel); // This will do the update

            _repository.UpdateServiceProvider(SPModel); // This does nothing

            _repository.SaveChanges(); // Saves the update done by the mapepr

            return Ok(_mapper.Map<ServiceProviderReadDto>(SPModel));

        }

        // Patch api/service_provider/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialServiceProviderUpdate(int id, JsonPatchDocument<ServiceProviderUpdateDto> patchDocument)
        {
            var SPModel = _repository.GetServiceProviderById(id);
            if(SPModel == null)
            {
                return NotFound();
            }

            var SPToPatch = _mapper.Map<ServiceProviderUpdateDto>(SPModel);
            patchDocument.ApplyTo(SPToPatch, ModelState);

            if (!TryValidateModel(SPToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(SPToPatch, SPModel);

            _repository.UpdateServiceProvider(SPModel); // does nothing

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/service_provider/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteServiceProvider(int id)
        {
            var SPModel = _repository.GetServiceProviderById(id);
            if (SPModel == null)
            {
                return NotFound();
            }
            _repository.DeleteServiceProvider(SPModel);
            _repository.SaveChanges();

            return Ok();
        }

        // GET api/trucks/service_provider/{SPId}
        [HttpGet("{SPId}/trucks")]
        public ActionResult<IEnumerable<Truck>> GetTrucksForSP(int SPId)
        {
            var trucks = _repository.GetServiceProviderById(SPId).Trucks;

            if (trucks == null)
            {
                return NotFound();
            }

            var trucksReadDto = _mapper.Map<IEnumerable<TruckReadDto>>(trucks);

            return Ok(trucksReadDto);
        }

     




        // POST api/service_provider/SPId/trucks/
        [HttpPost("{SPId}/trucks")]
        public ActionResult<Truck> PostTruckForSP(int SPId , TruckCreateDto truckCreateDto)
        {
            var truckModel = _mapper.Map<Truck>(truckCreateDto);
            var SPModel = _repository.GetServiceProviderById(SPId);
            if (SPModel == null)
            {
                return NotFound("SPID is "+SPId);
            }
            truckModel.ServiceProvider = SPModel;
            _repository.PostTruck(truckModel);
            _repository.SaveChanges();

            var truckReadDto = _mapper.Map<TruckReadDto>(truckModel);

            return CreatedAtRoute(nameof(TrucksController.GetTruckById), new { Id = truckReadDto.TruckId }, truckReadDto);

        }

    }
}
