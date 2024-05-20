using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Application.Services;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Core.Repositories;
using Moq;
using System.Linq.Expressions;
using GerenciadorRestaurante.Core.Enums;
using GerenciadorRestaurante.Core.Exceptions;

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
            var reservaInputModel = new ReservaInputModel
            {
                DataReserva = DateTime.Now,
                QuantidadePessoas = 4,
                Observacao = "Reserva de teste",
                StatusReserva = StatusReserva.Confirmada,
                MesaId = 1,
                UsuarioId = 1,
                RestauranteId = 1
            };

            var reserva = new Reserva
            {
                DataReserva = reservaInputModel.DataReserva,
                QuantidadePessoas = reservaInputModel.QuantidadePessoas,
                Observacao = reservaInputModel.Observacao,
                StatusReserva = reservaInputModel.StatusReserva,
                MesaId = reservaInputModel.MesaId,
                UsuarioId = reservaInputModel.UsuarioId,
                RestauranteId = reservaInputModel.RestauranteId
            };

            var reservaViewModel = new ReservaViewModel
            {
                DataReserva = reservaInputModel.DataReserva,
                QuantidadePessoas = reservaInputModel.QuantidadePessoas,
                Observacao = reservaInputModel.Observacao,
                StatusReserva = reservaInputModel.StatusReserva,
                Mesa = new Mesa { Id = reservaInputModel.MesaId },  
                Usuario = new Usuario { Id = reservaInputModel.UsuarioId },  
                Restaurante = new Restaurante { Id = reservaInputModel.RestauranteId }  
            };

            _mapperMock.Setup(mapper => mapper.Map<Reserva>(reservaInputModel)).Returns(reserva);
            _reservaRepositoryMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Reserva, bool>>>())).ReturnsAsync(false);
            _reservaRepositoryMock.Setup(repo => repo.InserirAsync(reserva)).ReturnsAsync(reserva);
            _mapperMock.Setup(mapper => mapper.Map<ReservaViewModel>(reserva)).Returns(reservaViewModel);

            // Act
            var result = await _reservaService.CadastrarReserva(reservaInputModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(reservaViewModel.DataReserva, result.DataReserva);
            Assert.AreEqual(reservaViewModel.QuantidadePessoas, result.QuantidadePessoas);
            Assert.AreEqual(reservaViewModel.Observacao, result.Observacao);
            Assert.AreEqual(reservaViewModel.StatusReserva, result.StatusReserva);
            Assert.AreEqual(reservaViewModel.Mesa.Id, result.Mesa.Id);
            Assert.AreEqual(reservaViewModel.Usuario.Id, result.Usuario.Id);
            Assert.AreEqual(reservaViewModel.Restaurante.Id, result.Restaurante.Id);
        }

        [Test]
        public void CadastrarReserva_QuandoReservaJaExiste_DeveLancarAlreadyExistsException()
        {
            // Arrange
            var reservaInputModel = new ReservaInputModel
            {
                DataReserva = DateTime.Now,
                QuantidadePessoas = 4,
                Observacao = "Reserva de teste",
                StatusReserva = StatusReserva.Confirmada,
                MesaId = 1,
                UsuarioId = 1,
                RestauranteId = 1
            };

            _reservaRepositoryMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Reserva, bool>>>())).ReturnsAsync(true);

            // Act & Assert
            var ex = Assert.ThrowsAsync<AlreadyExistsException>(() => _reservaService.CadastrarReserva(reservaInputModel));
            Assert.AreEqual("A reserva já existe.", ex.Message);
        }

        [Test]
        public void CadastrarReserva_QuandoMapeamentoFalha_DeveLancarException()
        {
            // Arrange
            var reservaInputModel = new ReservaInputModel
            {
                DataReserva = DateTime.Now,
                QuantidadePessoas = 4,
                Observacao = "Reserva de teste",
                StatusReserva = StatusReserva.Confirmada,
                MesaId = 1,
                UsuarioId = 1,
                RestauranteId = 1
            };

            _mapperMock.Setup(mapper => mapper.Map<Reserva>(reservaInputModel)).Throws(new Exception("Erro no mapeamento"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _reservaService.CadastrarReserva(reservaInputModel));
            Assert.AreEqual("Erro no mapeamento", ex.Message);
        }

        [Test]
        public void CadastrarReserva_QuandoInsercaoFalha_DeveLancarException()
        {
            // Arrange
            var reservaInputModel = new ReservaInputModel
            {
                DataReserva = DateTime.Now,
                QuantidadePessoas = 4,
                Observacao = "Reserva de teste",
                StatusReserva = StatusReserva.Confirmada,
                MesaId = 1,
                UsuarioId = 1,
                RestauranteId = 1
            };

            var reserva = new Reserva
            {
                DataReserva = reservaInputModel.DataReserva,
                QuantidadePessoas = reservaInputModel.QuantidadePessoas,
                Observacao = reservaInputModel.Observacao,
                StatusReserva = reservaInputModel.StatusReserva,
                MesaId = reservaInputModel.MesaId,
                UsuarioId = reservaInputModel.UsuarioId,
                RestauranteId = reservaInputModel.RestauranteId
            };

            _mapperMock.Setup(mapper => mapper.Map<Reserva>(reservaInputModel)).Returns(reserva);
            _reservaRepositoryMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Reserva, bool>>>())).ReturnsAsync(false);
            _reservaRepositoryMock.Setup(repo => repo.InserirAsync(reserva)).ThrowsAsync(new Exception("Erro ao inserir no repositório"));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(() => _reservaService.CadastrarReserva(reservaInputModel));
            Assert.AreEqual("Erro ao inserir no repositório", ex.Message);
        }
    }
}
