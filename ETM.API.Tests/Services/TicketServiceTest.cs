using ETM.API.Core.Entities;
using ETM.API.Repository.Context;
using ETM.API.Repository.Services;
using ETM.API.Service.Services;
using ETM.API.Tests.Helpers;

using Microsoft.Extensions.Logging;

using NSubstitute;

using System.Linq.Expressions;

namespace ETM.API.Tests.Services
{
    [TestClass]
    public class TicketServiceTest
    {
        private DataContext _dataContext;
        private ILogger<UnitOfWork> _logger;
        private TicketService _sut;

        private DateTime _currentDateTime = DateTime.UtcNow;
        private DateTime _laterDateTime = DateTime.UtcNow.AddDays(1);

        [TestInitialize]
        public void Initialize()
        {
            _logger = Substitute.For<ILogger<UnitOfWork>>();
            _dataContext = MemoryDataContext.GetMemoryDataContext();
            var unitOfWork = new UnitOfWork(_dataContext, _logger);
            _sut = new TicketService(unitOfWork);

            InitializeData();
        }

        [TestMethod]
        public void AddTicketAsync_SuccessfullyAddTicket()
        {
            //Arrange
            int count = _dataContext.Tickets.Count();

            //Assert
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public async Task DeleteTicketAsync_SuccessfullyDeleteTicket()
        {
            //Arrange
            int count = _dataContext.Tickets.Count();

            //Act
            await _sut.DeleteTicketAsync(1);

            int countAfterDelete = _dataContext.Tickets.Count();

            //Assert
            Assert.AreEqual(5, count);
            Assert.AreEqual(4, countAfterDelete);
        }

        [TestMethod]
        public async Task DeleteTicketAsync_WhenInvalidIdReturnsFalse()
        {
            //Act
            bool status = await _sut.DeleteTicketAsync(10);

            //Assert
            Assert.IsFalse(status);
        }

        [TestMethod]
        public async Task GetAllTicketsAsync_WithDefaultPaging_ReturnsAllTickets()
        {

            //Arrange
            var filterConditionList = new List<Expression<Func<Ticket, bool>>>();

            //Act
            var tickets = await _sut.GetTicketsByFilterAsync(filterConditionList, 1, 10, true, null);

            //Assert
            Assert.AreEqual(5, tickets.Count());
        }

        [TestMethod]
        public async Task GetAllTicketsAsync_WithCustomPaging_ReturnsCorrectNumberOfTickets()
        {
            //Arrange
            var filterConditionList = new List<Expression<Func<Ticket, bool>>>();

            //Act
            var tickets = await _sut.GetTicketsByFilterAsync(filterConditionList, 1, 2, true, null);

            //Assert
            Assert.AreEqual(2, tickets.Count());

            tickets = await _sut.GetTicketsByFilterAsync(filterConditionList, 2, 2, true, null);
            Assert.AreEqual(2, tickets.Count());

            tickets = await _sut.GetTicketsByFilterAsync(filterConditionList, 3, 2, true, null);
            Assert.AreEqual(1, tickets.Count());

        }

        [TestMethod]
        public async Task GetTicketsByFilterAsync_WhenValidDueDate_ReturnsCorrectNumberOfTickets()
        {
            //Arrange
            var filterConditionList = new List<Expression<Func<Ticket, bool>>>();

            Expression<Func<Ticket, bool>> filterCondition = t => t.DueDate == _currentDateTime;

            filterConditionList.Add(filterCondition);

            //Act
            var tickets = await _sut.GetTicketsByFilterAsync(filterConditionList, 1, 100, true, null);

            //Assert
            Assert.AreEqual(4, tickets.Count());
        }

        [TestMethod]
        public async Task UpdateTicketAsync_WhenTicketIsNotNull_ProperlyUpdatesTicket()
        {
            //Arrange
            var ticket = await _sut.GetSingleTicketByIdAsync(1);
            ticket.DueDate = _laterDateTime;

            //Act
            bool status = await _sut.UpdateTicketAsync(1, ticket);
            var ticketAfterUpdate = await _sut.GetSingleTicketByIdAsync(1);

            //Assert
            Assert.IsTrue(status);
            Assert.AreEqual(_laterDateTime, ticketAfterUpdate.DueDate);
        }

        [TestMethod]
        public async Task UpdateTicketAsync_WhenInvalidTicketId_ReturnsFalse()
        {
            //Arrange
            var ticket = await _sut.GetSingleTicketByIdAsync(1);

            //Act
            bool status = await _sut.UpdateTicketAsync(10, ticket);

            //Assert
            Assert.IsFalse(status);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dataContext.Database.EnsureDeleted();
        }

        private async void InitializeData()
        {
            var ticket1 = new Ticket() { Id = 1, DueDate = _currentDateTime };
            var ticket2 = new Ticket() { Id = 2, DueDate = _currentDateTime };
            var ticket3 = new Ticket() { Id = 3, DueDate = _currentDateTime };
            var ticket4 = new Ticket() { Id = 4, DueDate = _currentDateTime };
            var ticket5 = new Ticket() { Id = 5, DueDate = _laterDateTime };

            await _sut.AddTicketAsync(ticket1);
            await _sut.AddTicketAsync(ticket2);
            await _sut.AddTicketAsync(ticket3);
            await _sut.AddTicketAsync(ticket4);
            await _sut.AddTicketAsync(ticket5);
        }
    }
}