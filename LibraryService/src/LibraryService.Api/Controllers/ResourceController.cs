using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;
using LibraryService.Infrastructure.Commands;
using LibraryService.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryService.Api.Controllers
{
    public class ResourceController : ApiControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService, ICommandDispatcher commandDispatcher) : base(commandDispatcher) 
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GenericResource>>> GetAll()
        {
            var resources = await _resourceService.GetAllAsync();
            
            return resources is null ? NotFound() : resources.ToList();
        }

        [HttpGet("find")]
        [Authorize]
        public async Task<ActionResult<List<GenericResource>>> GetByTitle(string title)
        {
            var resources = await _resourceService.GetAllAsync(title);
            return resources is null ? NotFound() : resources.ToList();
        }

        [HttpGet("details")]
        [Authorize]
        public async Task<ActionResult<List<Edition>>> GetDetails(string title)
        {
            var resources = await _resourceService.GetAllAsync(title);
            return resources is null ? NotFound() : resources.ToList()[0].Editions.ToList();
        }
    }
}