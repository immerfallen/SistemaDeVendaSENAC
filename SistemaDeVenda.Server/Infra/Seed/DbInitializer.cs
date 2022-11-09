using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeVenda.Server.Infra;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemaDeVenda.Server.Infra.Seed
{

    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public DbInitializer(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public async Task Initialize()
        {
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //create database schema if none exists
                var _context = serviceScope.ServiceProvider.GetService<SistemaDeVendaContext>();
                await _context.Database.MigrateAsync();
            }
        }
    }
}
