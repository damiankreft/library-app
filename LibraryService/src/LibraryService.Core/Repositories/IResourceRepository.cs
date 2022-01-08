using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;

namespace LibraryService.Core.Repositories
{
    public interface IResourceRepository : IRepository
    {
        Task<IEnumerable<GenericResource>> GetAllAsync();
        Task<GenericResource> GetAsync(int id);
        Task<IEnumerable<GenericResource>> GetAllAsync(string title);
        Task<bool> IsAvailable(int id);
    }
}