using LibraryService.Infrastructure.Dto;

namespace LibraryService.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email);
    }
}