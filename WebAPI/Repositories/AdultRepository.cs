using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using WebAPI.DataAccess;

namespace WebAPI.Repositories
{
    //with FirstOrDefaultAsync
    public class AdultRepository : IAdultRepository
    {
        private readonly MyDBContext _context;

        public AdultRepository(MyDBContext context)
        {
            _context = context;
        }
        
        public async Task<Adult> Add(Adult adult)
        {
            var result = await _context.Adults.AddAsync(adult);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Adult> Update(Adult adult)
        {
            var result = await _context.Adults.FirstOrDefaultAsync(e => e.Id == adult.Id);
            if (result != null)
            {
                result.FirstName = adult.FirstName;
                result.LastName = adult.LastName;
                result.HairColor = adult.HairColor;
                result.EyeColor = adult.EyeColor;
                result.Age = adult.Age;
                result.Weight = adult.Weight;
                result.Height = adult.Height;
                result.Sex = adult.Sex;
                result.JobTitle = adult.JobTitle;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Adult>> Get()
        {
            return await _context.Adults.ToListAsync();
        }

        public async Task<Adult> Get(int id)
        {
            return await _context.Adults.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Adult> Delete(int id)
        {
            var result = await _context.Adults.FirstOrDefaultAsync(a => a.Id == id);
            if (result != null)
            {
                _context.Adults.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}