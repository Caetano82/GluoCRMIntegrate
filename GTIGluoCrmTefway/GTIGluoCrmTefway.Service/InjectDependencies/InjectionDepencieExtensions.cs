using GTIGluoCrmTefway.IoC.Options;
using GTIGluoCrmTefway.Respository.Interfaces;
using GTIGluoCrmTefway.Respository.Repositorys;
using GTIGluoCrmTefway.Service.Interfaces;
using GTIGluoCrmTefway.Service.Providers.GluoCRM;
using GTIGluoCrmTefway.Service.Requests;
using GTIGluoCrmTefway.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GTIGluoCrmTefway.Service.InjectDependencies
{
    public static class InjectionDepencieExtensions
    {

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {

         
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IApiGluoCRMProvider, ApiGluoCRMProvider>();

            services.AddScoped<IGluoCRMServices, GluoCRMServices>();


            services.AddScoped<IApiGluoCRMProvider, ApiGluoCRMProvider>();
            services.AddScoped<IGluoCRMServices, GluoCRMServices>();
            services.AddScoped<IStarSoftService, StarSoftService>();


            

            var gluoCrmCredentialsSection = configuration.GetSection("GluoCRMCrendencials");
            
            var firstStep = new GluoCRMOperationTypesRequest(
                gluoCrmCredentialsSection["operationFirst"],
                gluoCrmCredentialsSection["operationSecond"],
                gluoCrmCredentialsSection["operationQuery"],
                gluoCrmCredentialsSection["username"],
                gluoCrmCredentialsSection["key"],
                gluoCrmCredentialsSection["queryContracts"],
                gluoCrmCredentialsSection["queryCustomer"],
                gluoCrmCredentialsSection["queryContacts"]



                );

            services.AddSingleton(firstStep);

        }

        public static void AddRepositorys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStarSoftRespository, StarSoftRespository>();

        }
    }
}

