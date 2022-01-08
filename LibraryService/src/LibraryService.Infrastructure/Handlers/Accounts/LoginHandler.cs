using LibraryService.Infrastructure.Commands;
using LibraryService.Infrastructure.Commands.Accounts;
using LibraryService.Infrastructure.Extensions;
using LibraryService.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace LibraryService.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IAccountService _accountService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IAccountService accountService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _accountService = accountService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            try
            {
                await _accountService.LoginAsync(command.Email, command.Password);
                
                var jwt = _jwtHandler.CreateToken(command.Email);
                // await _accountService.SetToken(command.Email, jwt.Token);
                _cache.SetJwt(command.TokenId, jwt);
            }
            catch (InvalidCredentialException ex)
            {
                // log exception
                throw;
            }
            catch (System.Exception ex)
            {
                // log exception
                throw;
            }
        }
    }
}