using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPI.DataAccess;

namespace WebAPI.Repositories
{
    //with FindAsync
    public class JobRepository : IJobRepository
    {
        private readonly MyDBContext _context;

        public JobRepository(MyDBContext context)
        {
            _context = context;
        }
        
        public async Task<Job> Add(Job job)
        {
            var result = await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Job> Update(Job job)
        {
            var result = await _context.Jobs.FindAsync(job.JobTitle);
            if (result != null)
            {
                result.Salary = job.Salary;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Job>> Get()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> Get(string jobTitle)
        {
            return await _context.Jobs.FindAsync(jobTitle);
        }

        public async Task<Job> Delete(string jobTitle)
        {
            var result = await _context.Jobs.FindAsync(jobTitle);
            if (result != null)
            {
                _context.Jobs.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}