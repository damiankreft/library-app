using LibraryService.Core.Repositories;

namespace LibraryService.Infrastructure.Services
{
    public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _repository;

        public LeaseService(ILeaseRepository repository)
        {
            _repository = repository;
        }

        
    }
}