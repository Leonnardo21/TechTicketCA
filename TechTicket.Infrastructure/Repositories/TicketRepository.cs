using Microsoft.EntityFrameworkCore;
using TechTicket.Domain.Abstractions;
using TechTicket.Domain.Entities;
using TechTicket.Infrastructure.Context;

namespace TechTicket.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TechTicketDbContext _context;

        public TicketRepository(TechTicketDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            if (_context is not null && ticket is not null && _context.Tickets is not null)
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }


        public async Task<IEnumerable<Ticket>> GetAllTicket()
        {
            if (_context is not null && _context.Tickets is not null)
            {
                var ticket = await _context.Tickets.ToListAsync();
                return ticket;
            }
            else
            {
                return new List<Ticket>();
            }
        }

        public async Task<Ticket?> GetTicket(Guid id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket is null)
                throw new InvalidOperationException($"Chamado com ID {id} não encontrado!");

            return ticket;
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            if (ticket is not null)
            {
                _context.Entry(ticket).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Dados inválidos...");
            }
        }
        public async Task DeleteTicket(Guid id)
        {
            var ticket = await GetTicket(id);

            if (ticket is not null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos...");
            }
        }
    }
}