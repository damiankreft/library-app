using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.Core.Domain;

namespace LibraryService.Core.Repositories
{
    public interface IAccountRepository : IRepository
    {
        Task AddAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetAsync(int id);
        Task<Account> GetAsync(string email);
        Task RemoveAsync(Account account);
        Task UpdateAsync(Account account);
    }
}