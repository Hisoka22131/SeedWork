using Microsoft.AspNetCore.Builder;

namespace SeedWork.IoC;

public abstract class Module : IModule
{
    public int OrderNumber { get; set; } = 0;

    public virtual void ConfigureServices(WebApplicationBuilder builder)
    {
    }

    public virtual void ConfigureApplication(WebApplication app)
    {
    }
}