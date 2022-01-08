using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;
using LibraryService.Core.Repositories;
using LibraryService.Infrastructure.Ef;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Infrastructure.Repositories
{
    public class LeaseRepository : ILeaseRepository
    {
        private readonly LibraryContext _context;

        public LeaseRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lease lease)
        {
            await _context.Leases.AddAsync(lease);
        }

        public async Task<Lease> GetAsync(int id)
            => await _context.Leases.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Lease>> GetResourceLeasesAsync(string resourceCode)
            => await _context.Leases.Where(x => x.ResourceInstanceId.Equals(resourceCode)).ToListAsync();
    }
}