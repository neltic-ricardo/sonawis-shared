using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sonawis.Shared.Api.Configuration;
public class ControllersServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);
    }
}
