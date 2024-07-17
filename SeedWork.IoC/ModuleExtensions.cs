using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SeedWork.IoC;

public static class ModuleExtensions
{
    public static void AddModule(this WebApplicationBuilder builder, params Type[] types)
    {
        try
        {
            var collection = builder.Services.BuildServiceProvider().GetService<ModulesCollection>()
                             ?? new ModulesCollection();

            foreach (var type in types.Distinct())
            {
                foreach (var item in type.Assembly.ExportedTypes
                             .Where(Predicate)
                             .Select(Activator.CreateInstance)
                             .OfType<IModule>()
                             .OrderBy(q => q.OrderNumber))
                {
                    collection.Modules.Add(item);
                }
            }

            foreach (var item in collection.Modules)
            {
                item.ConfigureServices(builder);
            }

            builder.Services.AddSingleton(collection);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public static void UseModule(this WebApplication source)
    {
        try
        {
            var collection = source.Services.GetService<ModulesCollection>()!;

            foreach (var item in collection.Modules)
            {
                item.ConfigureApplication(source);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private static bool Predicate(Type type)
    {
        return typeof(IModule).IsAssignableFrom(type);
    }
}