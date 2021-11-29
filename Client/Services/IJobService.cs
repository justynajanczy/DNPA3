using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Client.Services
{
    public interface IJobService
    {
        Task<Job> AddJob(Job job);
        Task<Job> UpdateJob(Job job);
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJob(string jobTitle);
        Task DeleteJob(string jobTitle);
    }
}