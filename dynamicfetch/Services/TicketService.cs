using dynamicfetch.Models;
using dynamicfetch.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dynamicfetch.Services;

public class TicketService : ITicketService
{
    private readonly DynamicFetchDbContext _context;

    public TicketService(DynamicFetchDbContext context)
    {
        _context = context;
    }

    public async Task SaveTicket(Ticket ticket)
    {
        try
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    public async Task<IEnumerable<Ticket>> GetTickets()
    { 
        return await _context.Tickets.ToListAsync();
    }
    
    
    public async Task<IEnumerable<TicketDto>?> ConsumeRestApi()
    { 
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1/comments");         
                return await response.Content.ReadFromJsonAsync<IEnumerable<TicketDto>>();    
            }
            
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
            return default;
        }      
    }
}