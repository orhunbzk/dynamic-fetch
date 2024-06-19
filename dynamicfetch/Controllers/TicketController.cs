using dynamicfetch.Models;
using dynamicfetch.Services;
using Microsoft.AspNetCore.Mvc;

namespace dynamicFetch.Controllers;

public class TicketController : Controller
{
    
    private readonly ITicketService _ticketService;
    
    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    
    public IActionResult CreateTicket()
    {
        return View();
    }
    
    //used for non animated page
    public async Task<IActionResult> TicketList()
    {
        var ticketsFromDb = await _ticketService.GetTickets();
        var ticketsFromRestApi = await _ticketService.ConsumeRestApi();

        var ticketViewModel = new TicketViewModel 
        {
            Tickets = ticketsFromDb,
            TicketDto = ticketsFromRestApi
        };
        return View(ticketViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTicket(Ticket request)
    {
        if (request is not null)
        {
            await _ticketService.SaveTicket(request);
            return RedirectToAction("TicketList");
        }
        return BadRequest();
    }

    #region Dynamicpage

    public IActionResult TicketListAnimation()
    {
        return View();
    }
    

    //used for animated (dynamically rendered page) first call
    [HttpGet]
    public async Task<IEnumerable<Ticket>> GetTicketsFromDb()
    {
        return await _ticketService.GetTickets();    
    }
    
    #endregion
    
}