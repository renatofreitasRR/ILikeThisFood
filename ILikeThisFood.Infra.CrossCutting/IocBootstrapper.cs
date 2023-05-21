using ILikeThisFood.Domain.Repositories;
using ILikeThisFood.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ILikeThisFood.Infra.CrossCutting
{
    public static class IocBootstrapper
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
        }
    }
}