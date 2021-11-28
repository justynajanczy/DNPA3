using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdultsController : ControllerBase
    {
        private readonly IAdultRepository _adultRepository;

        public AdultsController(IAdultRepository adultsRepository)
        {
            _adultRepository = adultsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAdults()
        {
            try
            {
                return Ok(await _adultRepository.Get());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            try
            {
                var result = await _adultRepository.Get(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception  e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdult(Adult adult)
        {
            try
            {
                if (adult == null)
                    return BadRequest();
                var newAdult = await _adultRepository.Add(adult);
                return CreatedAtAction(nameof(GetAdults), new {id = newAdult.Id}, newAdult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Adult>> PutAdult(Adult adult)
        {
            try
            {
                var adultToUpdate = await _adultRepository.Get(adult.Id);
                if (adultToUpdate == null)
                    return NotFound($"Adult with id = {adult.Id} not found");
                return await _adultRepository.Update(adult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Adult>> DeleteAdult(int id)
        {
            try
            {
                var adultToDelete = await _adultRepository.Get(id);
                if (adultToDelete == null)
                    return NotFound($"Adult with id = {id} not found");
                return await _adultRepository.Delete(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retriving data from database");
            }
            
        }
    }
}