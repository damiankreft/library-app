using LibraryService.Core.Domain;
using LibraryService.Infrastructure.Dto;
using AutoMapper;

namespace LibraryService.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, AccountDto>();
                    cfg.CreateMap<AccountDto, Account>();
                })
                .CreateMapper();
    }
}