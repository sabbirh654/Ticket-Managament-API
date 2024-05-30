using ETM.API.Core.Entities;

using System.Linq.Expressions;

namespace ETM.API.Service.Interfaces
{
    public interface ITicketService
    {
        Task<bool> AddTicketAsync(Ticket entity);
        Task<bool> UpdateTicketAsync(int? ticketId, Ticket entity);
        Task<bool> DeleteTicketAsync(int? ticketId);
        Task<IEnumerable<Ticket>> GetTicketsByFilterAsync(List<Expression<Func<Ticket, bool>>> filterCondition, int pageNumber, int pageSize, bool isAscendingOrder, Expression<Func<Ticket, DateTime>> sortCondition);
        Task<Ticket> GetSingleTicketByIdAsync(int? ticketId);
    }
}
