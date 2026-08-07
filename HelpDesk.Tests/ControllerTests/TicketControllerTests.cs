using HelpDesk.Api.Controllers;
using HelpDesk.Api.Models;
using HelpDesk.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HelpDesk.Tests.ControllerTests
{
    public class TicketControllerTests
    {
        private readonly Mock<ITicketRepository> _mockRepository;
        private readonly TicketController _controller;

        public TicketControllerTests()
        {
            _mockRepository = new Mock<ITicketRepository>();
            _controller = new TicketController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTickets_ReturnsOkResult()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Title = "Printer Issue",
                    Description = "Printer not working",
                    Priority = "High",
                    Status = "Open",
                    RaisedBy = "Sreelakshmi"
                }
            };

            _mockRepository
                .Setup(r => r.GetAllTicketsAsync())
                .ReturnsAsync(tickets);

            // Act
            var result = await _controller.GetAllTickets();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<List<Ticket>>(okResult.Value);

            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetTicketById_ReturnsOk_WhenTicketExists()
        {
            // Arrange
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Printer Issue",
                Description = "Printer not working",
                Priority = "High",
                Status = "Open",
                RaisedBy = "Sreelakshmi"
            };

            _mockRepository
                .Setup(r => r.GetTicketByIdAsync(1))
                .ReturnsAsync(ticket);

            // Act
            var result = await _controller.GetTicketById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTicketById_ReturnsNotFound_WhenTicketDoesNotExist()
        {
            // Arrange
            _mockRepository
                .Setup(r => r.GetTicketByIdAsync(100))
                .ReturnsAsync((Ticket?)null);

            // Act
            var result = await _controller.GetTicketById(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsCreatedAtAction()
        {
            // Arrange
            var ticket = new Ticket
            {
                Id = 1,
                Title = "New Ticket",
                Description = "Test Description",
                Priority = "Medium",
                Status = "Open",
                RaisedBy = "Sreelakshmi"
            };

            _mockRepository
                .Setup(r => r.CreateTicketAsync(ticket))
                .ReturnsAsync(1);

            // Act
            var result = await _controller.CreateTicket(ticket);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task DeleteTicket_ReturnsNoContent()
        {
            // Arrange
            _mockRepository
                .Setup(r => r.DeleteTicketAsync(1))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteTicket(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}