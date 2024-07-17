using Microsoft.AspNetCore.Builder;

namespace SeedWork.IoC;

public interface IModule
{
    public int OrderNumber { get; set; }
    
    void ConfigureServices(WebApplicationBuilder builder);
    
    void ConfigureApplication(WebApplication app);
}