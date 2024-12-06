using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbiental.Controllers;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Services;
using Moq;
using Xunit;

namespace MonitoramentoAmbiental.Teste.Controllers
{
    public class ParqueControllerTests
    {
        private readonly Mock<IParqueService> _mockParqueService;
        private readonly ParqueController _controller;

        public ParqueControllerTests()
        {
            _mockParqueService = new Mock<IParqueService>();
            _controller = new ParqueController(_mockParqueService.Object);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfParques()
        {
            // Arrange
            var parques = new List<Parque>
            {
                new Parque { Id = 1, Nome = "Parque A" },
                new Parque { Id = 2, Nome = "Parque B" }
            };

            _mockParqueService.Setup(service => service.GetAllAsync()).ReturnsAsync(parques);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Parque>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Create_Post_ReturnsRedirectToActionResult_WhenModelIsValid()
        {
            // Arrange
            var parque = new Parque { Id = 1, Nome = "Novo Parque" };

            _mockParqueService.Setup(service => service.CreateAsync(parque)).ReturnsAsync(parque);

            // Act
            var result = await _controller.Create(parque);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenParqueDoesNotExist()
        {
            // Arrange
            int invalidId = 999;
            _mockParqueService.Setup(service => service.GetByIdAsync(invalidId)).ReturnsAsync((Parque)null);

            // Act
            var result = await _controller.Edit(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Edit_Post_ReturnsRedirectToAction_WhenUpdateIsSuccessful()
        {
            // Arrange
            var parque = new Parque { Id = 1, Nome = "Parque Atualizado" };
            _mockParqueService.Setup(service => service.UpdateAsync(parque.Id, parque)).ReturnsAsync(parque);

            // Act
            var result = await _controller.Edit(parque.Id, parque);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
