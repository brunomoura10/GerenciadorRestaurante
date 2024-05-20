using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;
using Moq;
using NUnit.Framework;


namespace GerenciadorRestaurante.Testes.Services
{
    [TestFixture]
    public class RestauranteServiceTests
    {
        private RestauranteService _restauranteService;
        private Mock<IRestaurantRepository> _restauranteRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _restauranteRepositoryMock = new Mock<IRestaurantRepository>();
            _mapperMock = new Mock<IMapper>();
            _restauranteService = new RestauranteService(_restauranteRepositoryMock.Object, _mapperMock.Object);
        }

        #region sucesso
        [Test]
        public async Task CadastrarRestaurante_ShouldInsertRestaurante()
        {
            // Arrange
            var restauranteInputModel = new RestauranteInputModel();
            var restaurante = new Restaurante();
            _mapperMock.Setup(m => m.Map<Restaurante>(restauranteInputModel)).Returns(restaurante);

            // Act
            await _restauranteService.CadastrarRestaurante(restauranteInputModel);

            // Assert
            _restauranteRepositoryMock.Verify(r => r.InserirAsync(restaurante), Times.Once);
        }

        [Test]
        public async Task ObterTodos_ShouldReturnRestauranteViewModelList()
        {
            // Arrange
            var restaurantes = new List<Restaurante>();
            var restaurantesViewModel = new List<RestauranteViewModel>();

            _restauranteRepositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(restaurantes);
            _mapperMock.Setup(m => m.Map<List<RestauranteViewModel>>(restaurantes)).Returns(restaurantesViewModel);

            // Act
            var result = await _restauranteService.ObterTodos();

            // Assert
            Assert.AreEqual(restaurantesViewModel, result);
        }

        [Test]
        public async Task AtualizarRestaurante_ShouldUpdateRestaurante()
        {
            // Arrange
            var id = 1;
            var restauranteInputModel = new RestauranteInputModel();
            var restaurante = new Restaurante();
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(restaurante);
            _mapperMock.Setup(m => m.Map(restauranteInputModel, restaurante)).Returns(restaurante);

            // Act
            await _restauranteService.AtualizarRestaurante(id, restauranteInputModel);

            // Assert
            _restauranteRepositoryMock.Verify(r => r.AtualizarAsync(restaurante), Times.Once);
        }

        [Test]
        public async Task ObterPorId_ShouldReturnRestauranteViewModel()
        {
            // Arrange
            long id = 1;
            var restaurante = new Restaurante();
            var restauranteViewModel = new RestauranteViewModel();

            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(restaurante);
            _mapperMock.Setup(m => m.Map<RestauranteViewModel>(restaurante)).Returns(restauranteViewModel);

            // Act
            var result = await _restauranteService.ObterPorId(id);

            // Assert
            Assert.AreEqual(restauranteViewModel, result);
        }

        [Test]
        public async Task ExcluirRestaurante_ShouldDeleteRestaurante()
        {
            // Arrange
            var id = 1;
            var restaurante = new Restaurante();
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(restaurante);

            // Act
            await _restauranteService.ExcluirRestaurante(id);

            // Assert
            _restauranteRepositoryMock.Verify(r => r.ExcluirAsync(restaurante), Times.Once);
        }

        public async Task ObterRestauranteComReservas_ShouldReturnRestauranteViewModel()
        {
            // Arrange
            long id = 1;
            DateTime dataReserva = DateTime.Now;
            var restaurante = new Restaurante();
            var restauranteViewModel = new RestauranteViewModel();

            _restauranteRepositoryMock.Setup(repo => repo.ObterRestauranteComReservasAsync(id, dataReserva))
                .ReturnsAsync(restaurante);
            _mapperMock.Setup(mapper => mapper.Map<RestauranteViewModel>(restaurante))
                .Returns(restauranteViewModel);

            // Act
            var result = await _restauranteService.ObterRestauranteComReservas(id, dataReserva);

            // Assert
            Assert.AreEqual(restauranteViewModel, result);
        }

        #endregion

        #region falha
        [Test]
        public void ExcluirRestaurante_RestauranteNaoEncontradoException()
        {
            // Arrange
            var id = 1;
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Restaurante)null);

            // Act
            var exception = Assert.ThrowsAsync<RestauranteNaoEncontradoException>(() => _restauranteService.ExcluirRestaurante(id));

            // Assert
            Assert.AreEqual("Restaurante não encontrado na base de dados", exception.Message);
        }

        [Test]
        public async Task ObterRestauranteComReservas_ShouldThrowRestauranteNaoEncontradoException()
        {
            // Arrange
            long id = 1;
            DateTime dataReserva = DateTime.Now;

            _restauranteRepositoryMock.Setup(repo => repo.ObterRestauranteComReservasAsync(id, dataReserva))
                .ReturnsAsync((Restaurante)null);

            // Act & Assert
             Assert.ThrowsAsync<RestauranteNaoEncontradoException>(
                () => _restauranteService.ObterRestauranteComReservas(id, dataReserva));
        }

        [Test]
        public async Task ObterRestauranteComReservas_ShouldThrowNehumaReservaEncontradaParadaRestaurante()
        {
            // Arrange
            long id = 1;
            DateTime dataReserva = DateTime.Now;
            var restaurante = new Restaurante();
            restaurante.Reservas = new List<Reserva>(); 

            _restauranteRepositoryMock.Setup(repo => repo.ObterRestauranteComReservasAsync(id, dataReserva))
                .ReturnsAsync(restaurante);

            // Act & Assert
            Assert.ThrowsAsync<NehumaReservaEncontradaParadaRestaurante>(
                () => _restauranteService.ObterRestauranteComReservas(id, dataReserva));
        }

        [Test]
        public void ObterPorId_RestauranteNaoEncontradoException()
        {
            // Arrange
            long id = 1;
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Restaurante)null);

            // Act
            var exception = Assert.ThrowsAsync<RestauranteNaoEncontradoException>(() => _restauranteService.ObterPorId(id));

            // Assert
            Assert.AreEqual("Restaurante não encontrado na base de dados", exception.Message);
        }
        [Test]
        public void AtualizarRestaurante_RestauranteNaoEncontradoException()
        {
            // Arrange
            var id = 1;
            var restauranteInputModel = new RestauranteInputModel();
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Restaurante)null);

            // Act
            var exception = Assert.ThrowsAsync<RestauranteNaoEncontradoException>(() => _restauranteService.AtualizarRestaurante(id, restauranteInputModel));

            // Assert
            Assert.AreEqual("Restaurante não encontrado na base de dados", exception.Message);
        }


        #endregion  

    }
}
