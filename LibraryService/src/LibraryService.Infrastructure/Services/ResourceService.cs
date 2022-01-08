using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;
using LibraryService.Core.Repositories;
using System.Linq;
using System;

namespace LibraryService.Infrastructure.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _repository;
        public ResourceService(IResourceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GenericResource>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<IEnumerable<GenericResource>> GetAllAsync(string title)
            => await _repository.GetAllAsync(title);

        public async Task<GenericResource> GetAsync(int id)
            => await _repository.GetAsync(id);

        public async Task<bool> IsAvailable(int id)
        {
            throw new NotImplementedException();
        }
    }
}