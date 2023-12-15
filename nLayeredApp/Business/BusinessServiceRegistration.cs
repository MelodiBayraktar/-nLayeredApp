using System.Reflection;
using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceRegistration {
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<CategoryBusinessRules>();
        return services; 
    } 
}