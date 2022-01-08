using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;

namespace LibraryService.Core.Repositories
{
    public interface ILeaseRepository
    {
        Task AddAsync(Lease account);
        Task<IEnumerable<Lease>> GetResourceLeasesAsync(string resourceCode);
        Task<Lease> GetAsync(int id);
    }
}