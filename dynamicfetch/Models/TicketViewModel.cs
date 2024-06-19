namespace dynamicfetch.Models;
public class TicketViewModel
{
    //tickets from db
    public IEnumerable<Ticket> Tickets { get; set; }

    //tickets - posts from rest api 
    public IEnumerable<TicketDto> TicketDto { get; set; }
}