using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Infra.Data.Identity;
using EstoqueOnline.Infra.Data.NoSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EstoqueOnline.Infra.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region MongoDB
            services.AddSingleton<EstoqueContext>();
            #endregion
            #region SQL
            services.AddDbContext<UsuarioContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("UserDb"),
            b => b.MigrationsAssembly(typeof(UsuarioContext).Assembly.FullName)));
            #endregion
            return services;
        }

    }
}