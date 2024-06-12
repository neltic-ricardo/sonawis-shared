using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sonawis.Shared.Api.Configuration;
public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
