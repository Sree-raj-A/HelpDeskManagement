using HelpDesk.Api.Data;
using HelpDesk.Api.Models;
using HelpDesk.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HelpDesk.Tests.RepositoryTests
{
    public class TicketRepositoryTests
    {
        private HelpDeskContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<HelpDeskContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new HelpDeskContext(options);
        }

        [Fact]
        public async Task CreateTicketAsync_ShouldAddTicket()
        {
            // Arrange
            var context = GetDbContext();
            var repository = new TicketRepository(context);

            var ticket = new Ticket
            {
                Title = "Printer Issue",
                Description = "Printer not working",
                Priority = "High",
                Status = "Open",
                RaisedBy = "Sreelakshmi"
            };

            // Act
            await repository.CreateTicketAsync(ticket);

            // Assert
            Assert.Single(context.Tickets);
        }

        [Fact]
        public async Task GetAllTicketsAsync_ShouldReturnTickets()
        {
            // Arrange
            var context = GetDbContext();

            context.Tickets.Add(new Ticket
            {
                Title = "Test",
                Description = "Test",
                Priority = "Low",
                Status = "Open",
                RaisedBy = "Admin"
            });

            await context.SaveChangesAsync();

            var repository = new TicketRepository(context);

            // Act
            var result = await repository.GetAllTicketsAsync();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task DeleteTicketAsync_ShouldRemoveTicket()
        {
            // Arrange
            var context = GetDbContext();

            var ticket = new Ticket
            {
                Title = "Delete Test",
                Description = "Delete",
                Priority = "Medium",
                Status = "Open",
                RaisedBy = "Admin"
            };

            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            var repository = new TicketRepository(context);

            // Act
            await repository.DeleteTicketAsync(ticket.Id);

            // Assert
            Assert.Empty(context.Tickets);
        }
    }
}