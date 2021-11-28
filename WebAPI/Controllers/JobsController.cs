using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;

        public JobsController(IJobRepository jobsRepository)
        {
            _jobRepository = jobsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetJobs()
        {
            try
            {
                return Ok(await _jobRepository.Get());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(string jobTitle)
        {
            try
            {
                var result = await _jobRepository.Get(jobTitle);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception  e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            try
            {
                if (job == null)
                    return BadRequest();
                var newJob = await _jobRepository.Add(job);
                return CreatedAtAction(nameof(GetJobs), new {jobTitle = newJob.JobTitle}, newJob);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving data from database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Job>> PutJob(Job job)
        {
            try
            {
                var jobToUpdate = await _jobRepository.Get(job.JobTitle);
                if (jobToUpdate == null)
                    return NotFound($"Job with id = {job.JobTitle} not found");
                return await _jobRepository.Update(job);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(string jobTitle)
        {
            try
            {
                var jobToDelete = await _jobRepository.Get(jobTitle);
                if (jobToDelete == null)
                    return NotFound($"Job with id = {jobTitle} not found");
                return await _jobRepository.Delete(jobTitle);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving data from database");
            }
            
        }
    }
}