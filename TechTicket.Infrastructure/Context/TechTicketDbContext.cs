using Microsoft.EntityFrameworkCore;
using TechTicket.Domain.Entities;

namespace TechTicket.Infrastructure.Context
{
    public class TechTicketDbContext : DbContext
    {
        public TechTicketDbContext(DbContextOptions options): base(options) { }

        public DbSet<Ticket?> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(TechTicketDbContext).Assembly);
        }
    }
}
