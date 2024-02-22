using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTicket.Domain.Entities;

namespace TechTicket.Infrastructure.EntitiesConfiguration
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.RequestingStore).IsRequired().HasMaxLength(80);
            builder.Property(x => x.EmailStore).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneStore).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();

        }
    }
}
