using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Application.Services;
using EstoqueOnline.Infra.Data.NoSQL;
using EstoqueOnline.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace EstoqueOnline.Infra.IoC
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddRepoAndServices(this IServiceCollection services)
        {
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            return services;
        }

    }
}
