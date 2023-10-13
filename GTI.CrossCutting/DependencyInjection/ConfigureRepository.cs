using GTI.Data.Context;
using GTI.Data.Repository;
using GTI.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GTI.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            string connectionString = "Data Source=LAPTOP-1P8P1N60\\SQLEXPRESS;Initial Catalog=Clientes;Integrated Security=True;";
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<UserContext>(
                options => options.UseSqlServer(connectionString)
            );

        }
    }
}
