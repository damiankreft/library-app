using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Infrastructure.Dto;

namespace LibraryService.Infrastructure.Services
{
    public interface IAccountService : IService
    {
        Task<List<AccountDto>> GetAllAsync();
        Task<AccountDto> GetAsync(string email);
        Task LoginAsync(string email, string password);
        Task RegisterAsync(string email, string lastname, string firstname, string password);
        Task SetToken(string email, string token);
    }
}