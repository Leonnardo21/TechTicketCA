using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTicket.Domain.Abstractions;
using TechTicket.Infrastructure.Context;
using TechTicket.Infrastructure.Repositories;

namespace TechTicket.CrossCutting.DependenciesApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<TechTicketDbContext>(opt => opt.UseSqlite(connectionString));

            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
