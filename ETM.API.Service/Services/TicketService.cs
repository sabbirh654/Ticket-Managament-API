using ETM.API.Core.Entities;
using ETM.API.Core.Exceptions;
using ETM.API.Infrastructure.Interfaces;
using ETM.API.Service.Interfaces;

using System.Linq.Expressions;

namespace ETM.API.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            try
            {
                ticket.CreatedOn = DateTime.UtcNow;
                await _unitOfWork.TicketRepository.AddAsync(ticket);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in TicketService : AddTicketAsync(Ticket ticket) method", ex);
            }

        }

        public async Task<bool> DeleteTicketAsync(int? ticketId)
        {
            try
            {
                var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(ticketId);

                if (ticket != null)
                {
                    await _unitOfWork.TicketRepository.DeleteAsync(ticket);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in TicketService : DeleteTicketAsync(int? ticketId) method", ex);
            }
        }

        public async Task<Ticket> GetSingleTicketByIdAsync(int? ticketId)
        {
            try
            {
                var result = await _unitOfWork.TicketRepository.GetByIdAsync(ticketId);
                return result;
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in TicketService : GetSingleTicketByIdAsync(int? ticketId) method", ex);
            }
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByFilterAsync(List<Expression<Func<Ticket, bool>>> filterCondition, int pageNumber, int pageSize, bool isAscendingOrder, Expression<Func<Ticket, DateTime>>? sortCondition)
        {
            try
            {
                var result = await _unitOfWork.TicketRepository.FilterByAsync(filterCondition, pageNumber, pageSize, isAscendingOrder, sortCondition);
                return result;
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in TicketService : GetTicketsByFilterAsync() method", ex);
            }
        }

        public async Task<bool> UpdateTicketAsync(int? ticketId, Ticket updatedTicket)
        {
            try
            {
                Ticket ticket = await _unitOfWork.TicketRepository.GetByIdAsync(ticketId);

                if (ticket != null)
                {
                    ticket.ModifiedBy = updatedTicket.ModifiedBy;
                    ticket.DueDate = updatedTicket.DueDate;
                    ticket.ModifiedOn = DateTime.UtcNow;

                    await _unitOfWork.TicketRepository.UpdateAsync(ticket);
                    await _unitOfWork.CommitAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ETMException("Error in TicketService : UpdateTicketAsync(int? ticketId, Ticket updatedTicket) method", ex);
            }
        }
    }
}
