using ETM.API.Core.Entities;

namespace ETM.API.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IETMRepository<Ticket> TicketRepository { get; }
        IETMRepository<Comment> CommentRepository { get; }
        Task CommitAsync();
    }
}
