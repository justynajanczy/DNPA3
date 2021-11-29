using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Client.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;

        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<Job> AddJob(Job job)
        {
            return await _httpClient.PostJsonAsync<Job>("Jobs", job);
        }

        public async Task<Job> UpdateJob(Job job)
        {
            return await _httpClient.PutJsonAsync<Job>("Jobs", job);
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _httpClient.GetFromJsonAsync<Job[]>("Jobs");
        }

        public async Task<Job> GetJob(string jobTitle)
        {
            return await _httpClient.GetFromJsonAsync<Job>($"Job/{jobTitle}");
        }

        public async Task DeleteJob(string jobTitle)
        {
            await _httpClient.DeleteAsync($"Jobs/{jobTitle}");
        }
    }
}