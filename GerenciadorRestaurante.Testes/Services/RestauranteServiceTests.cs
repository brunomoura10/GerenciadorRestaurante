using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
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
        
        #endregion  

    }
}
