using LibraryService.Infrastructure.Extensions;
using LibraryService.Infrastructure.Settings;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace LibraryService.Infrastructure.Ioc.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                .SingleInstance();
        }
    }
}