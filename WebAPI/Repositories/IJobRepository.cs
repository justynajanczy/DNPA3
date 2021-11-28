using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Repositories
{
    public interface IJobRepository
    {
        Task<Job> Add(Job job);
        Task<Job> Update(Job job);
        Task<IEnumerable<Job>> Get();
        Task<Job> Get(string JobTitle);
        Task<Job> Delete(string jobTitle);
    }
}