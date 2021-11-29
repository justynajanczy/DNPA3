using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace Client.Services
{
    public class AdultService : IAdultService
    {
        private readonly HttpClient _httpClient;

        public AdultService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<Adult> AddAdult(Adult adult)
        {
            return await _httpClient.PostJsonAsync<Adult>("Adults", adult);
        }

        public async Task<Adult> UpdateAdult(Adult adult)
        {
            return await _httpClient.PutJsonAsync<Adult>("Adults", adult);
        }

        public async Task<IEnumerable<Adult>> GetAdults()
        {
            return await _httpClient.GetFromJsonAsync<Adult[]>("Adults");
        }

        public async Task<Adult> GetAdult(int id)
        {
            return await _httpClient.GetFromJsonAsync<Adult>($"Adults/{id}");
        }

        public async Task DeleteAdult(int id)
        {
            await _httpClient.DeleteAsync($"Adults/{id}");
        }
    }
}