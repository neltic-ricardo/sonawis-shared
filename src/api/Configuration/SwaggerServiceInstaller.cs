using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sonawis.Shared.Api.Configuration;
public class SwaggerServiceInstaller : IServiceInstaller
{
    public void Install(
        IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddSwaggerGen();
    }
}
