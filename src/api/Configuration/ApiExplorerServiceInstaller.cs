using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sonawis.Shared.Api.Configuration;
public class ApiExplorerServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
    }
}
