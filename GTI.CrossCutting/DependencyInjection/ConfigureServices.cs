using GTI.Data.Repository;
using GTI.Domain.Entity;
using GTI.Domain.Interfaces.Services;
using GTI.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GTI.CrossCutting.DependencyInjection
{
    public class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IEnderecoServices, EnderecoServices>();
        }
    }
}
