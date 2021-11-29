using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Client.Services
{
    public interface IAdultService
    {
        Task<Adult> AddAdult(Adult adult);
        Task<Adult> UpdateAdult(Adult adult);
        Task<IEnumerable<Adult>> GetAdults();
        Task<Adult> GetAdult(int id);
        Task DeleteAdult(int id);
    }
}