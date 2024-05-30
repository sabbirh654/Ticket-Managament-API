using ETM.API.Core.Entities;
using ETM.API.Infrastructure.Interfaces;
using ETM.API.Infrastructure.Services;
using ETM.API.Repository.Context;

using Microsoft.Extensions.Logging;

namespace ETM.API.Repository.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        private IETMRepository<Ticket>? _ticketRepository;
        private IETMRepository<Comment>? _commentRepository;

        private bool disposed = false;

        public UnitOfWork(DataContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IETMRepository<Ticket> TicketRepository
        {
            get { return _ticketRepository ?? (_ticketRepository = new ETMRepository<Ticket>(_context)); }
        }

        public IETMRepository<Comment> CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new ETMRepository<Comment>(_context)); }
        }

        public async Task CommitAsync()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Database transaction can't be performed successfully. Error : {ex.Message}");
                    _context.Dispose();
                    transaction.Rollback();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
