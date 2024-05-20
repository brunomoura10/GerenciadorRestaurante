using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Application.Services;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Core.Repositories;
using Moq;
using System.Linq.Expressions;

namespace GerenciadorRestaurante.Testes.Entites
{
    [TestFixture]
    public class ReservaServiceTests
    {
        private ReservaService _reservaService;
        private Mock<IReservaRepository> _reservaRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _reservaRepositoryMock = new Mock<IReservaRepository>();
            _mapperMock = new Mock<IMapper>();
            _reservaService = new ReservaService(_reservaRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CadastrarReserva_QuandoReservaNaoExiste_DeveCadastrarERetornarReservaViewModel()
        {
            // Arrange
            var reservaInputModel = new ReservaInputModel(); // Preencha com os dados necessários para o teste
            var reserva = new Reserva(); // Preencha com os dados necessários para o teste
            var reservaViewModel = new ReservaViewModel(); // Preencha com os dados esperados

            _mapperMock.Setup(mapper => mapper.Map<Reserva>(reservaInputModel)).Returns(reserva);
            _reservaRepositoryMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Reserva, bool>>>())).ReturnsAsync(false);
            _reservaRepositoryMock.Setup(repo => repo.InserirAsync(reserva)).ReturnsAsync(reserva);
            _mapperMock.Setup(mapper => mapper.Map<ReservaViewModel>(reserva)).Returns(reservaViewModel);

            // Act
            var result = await _reservaService.CadastrarReserva(reservaInputModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(reservaViewModel, result);
        }

    }
}
