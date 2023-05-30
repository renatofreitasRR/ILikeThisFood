using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Infra.Data.Repositories;
using ILikeThisFood.Services.Storage.Contracts;
using ILikeThisFood.Services.Storage.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ILikeThisFood.Infra.CrossCutting
{
    public static class IocBootstrapper
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IFoodRepository, FoodRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }
    }
}