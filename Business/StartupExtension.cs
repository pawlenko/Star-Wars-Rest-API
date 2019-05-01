using Microsoft.Extensions.DependencyInjection;
using SW.Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Business
{
    public static class StartupExtension
    {
        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }
    }
}
