using System;
using System.Collections.Generic;
using ApiTest.Data;
using ApiTest.Dtos;
using ApiTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTest.Controllers
{
    [Route("api/trucks")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly IBarriRepo _repository;

        private readonly IMapper _mapper;

        public TrucksController( IBarriRepo repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        // GET api/trucks/
        [HttpGet]
        public ActionResult<IEnumerable<Truck>> GetTrucks()
        {
            var trucks = _repository.GetAllTrucks();

            if(trucks == null)
            {
                return NotFound();
            }

            var trucksReadDto = _mapper.Map < IEnumerable<TruckReadDto>>(trucks);

            return Ok(trucksReadDto);
        }

        // GET api/trucks/{id}
        [HttpGet("{id}",Name = "GetTruckById")]
        public ActionResult<Truck> GetTruckById(int id)
        {
            var truck = _repository.GetTruckById(id);
            
            if(truck == null)
            {
                return NotFound();
            }
            var truckReadDto = _mapper.Map<TruckReadDto>(truck);

            return Ok(truckReadDto);
        }

        // POST api/trucks/
        [HttpPost]
        public ActionResult<Truck> PostTruck(TruckCreateDto truckCreateDto)
        {
            var truckModel = _mapper.Map<Truck>(truckCreateDto);
            _repository.PostTruck(truckModel);
            _repository.SaveChanges();

            var truckReadDto = _mapper.Map<TruckReadDto>(truckModel);

            return CreatedAtRoute(nameof(GetTruckById), new {Id = truckReadDto.TruckId } , truckReadDto);
            
        }

        // PUT api/trucks/{id}
        [HttpPut("{id}")]
        public ActionResult<Truck> UpdateTruck(int id, TruckUpdateDto truckUpdateDto)
        {
            var truckModel = _repository.GetTruckById(id);
            if(truckModel == null)
            {
                return NotFound();
            }

            _mapper.Map(truckUpdateDto, truckModel); // This will do the update

            _repository.UpdateTruck(truckModel); // This does nothing

            _repository.SaveChanges(); // Saves the update done by the mapepr

            return Ok(_mapper.Map<TruckReadDto>(truckModel));

        }

        // Patch api/truck/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTruckUpdate(int id, JsonPatchDocument<TruckUpdateDto> patchDocument)
        {
            var truckModel = _repository.GetTruckById(id);
            if(truckModel == null)
            {
                return NotFound();
            }

            var truckToPatch = _mapper.Map<TruckUpdateDto>(truckModel);
            patchDocument.ApplyTo(truckToPatch, ModelState);

            if (!TryValidateModel(truckToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(truckToPatch, truckModel);

            _repository.UpdateTruck(truckModel); // does nothing

            _repository.SaveChanges();

            return NoContent();
        }



        // Patch api/truck/{id}/update_status
        [HttpPatch("{id}/update_condition")]
        public ActionResult<string> UpdateCondition(int id)
        {

            var truckModel = _repository.GetTruckById(id);
            if (truckModel == null)
            {
                return NotFound();
            }
            var modelYear = Int32.Parse(truckModel.ModelYear);
            var currentYear = DateTime.Now.Year;
            var truckAge = currentYear - modelYear;
            var condition = "New";
            if (truckAge > 5)
            {
                condition = "Old";

            }
            else if (truckAge > 2) {
                condition = "Average";
            }
            else
            {
                condition = "New";
            }

            var patchStatus = new JsonPatchDocument<TruckUpdateDto>();
            patchStatus.Operations.Add(new Operation<TruckUpdateDto> { op = "replace", path = "/condition", value = condition });

            var truckToPatch = _mapper.Map<TruckUpdateDto>(truckModel);
            patchStatus.ApplyTo(truckToPatch, ModelState);

            if (!TryValidateModel(truckToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(truckToPatch, truckModel);

            _repository.UpdateTruck(truckModel); // does nothing

            _repository.SaveChanges();

            return Ok(_mapper.Map<TruckReadDto>(truckModel));

            
        }

        //Delete api/truck/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTruck(int id)
        {
            var truckModel = _repository.GetTruckById(id);
            if(truckModel == null)
            {
                return NotFound();
            }
            _repository.DeleteTruck(truckModel);
            _repository.SaveChanges();

            return Ok();
        }
    }



    
}
