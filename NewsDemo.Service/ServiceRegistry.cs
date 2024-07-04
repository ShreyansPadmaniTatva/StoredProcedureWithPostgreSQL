using NewsDemo.Common;
using NewsDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;


namespace NewsDemo.Service
{
    public static class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<ITempDataDictionary, TempDataDictionary>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddScoped<IDapperService, DapperService>();

            // scan all dependency of solution
            services.AddDependencyScanning().ScanAssembly();
        }
    }
}