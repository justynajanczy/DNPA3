using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Repositories
{
    public interface IAdultRepository
    {
        Task<Adult> Add(Adult adult);
        Task<Adult> Update(Adult adult);
        Task<IEnumerable<Adult>> Get();
        Task<Adult> Get(int id);
        Task<Adult> Delete(int id);
    }
}