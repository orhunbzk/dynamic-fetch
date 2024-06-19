using dynamicfetch.Models;

namespace dynamicfetch.Services;

public interface ITicketService
{
    Task SaveTicket(Ticket ticket);
    Task<IEnumerable<Ticket>> GetTickets();
    Task<IEnumerable<TicketDto>?> ConsumeRestApi();
}