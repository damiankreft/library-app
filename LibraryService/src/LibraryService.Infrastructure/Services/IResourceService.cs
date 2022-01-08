using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;

namespace LibraryService.Infrastructure.Services
{
    public interface IResourceService : IService
    {
        Task<IEnumerable<GenericResource>> GetAllAsync();
        Task<IEnumerable<GenericResource>> GetAllAsync(string title);
        Task<GenericResource> GetAsync(int id);
        Task<bool> IsAvailable(int id);
    }
}