using TechTicket.Domain.Entities;

namespace TechTicket.Domain.Abstractions
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> GetAllTicket();
        Task<Ticket?> GetTicket(Guid id);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(Guid id);

    }
}
