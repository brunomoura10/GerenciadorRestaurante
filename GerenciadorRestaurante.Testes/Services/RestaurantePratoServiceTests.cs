using System;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;
using GerenciadorRestaurante.Infrastructure.Persistence.Repositorio;
using Moq;
using NUnit.Framework;

namespace GerenciadorRestaurante.Testes.Services
{
    [TestFixture]
    public class RestaurantePratoServiceTests
    {
        private RestaurantePratoService _restaurantePratoService;
        private Mock<IRestaurantePratoRepository> _restaurantePratoRepositoryMock;
        private Mock<IRestaurantRepository> _restauranteRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        
        public void Setup()
        {
            _restaurantePratoRepositoryMock = new Mock<IRestaurantePratoRepository>();
            _restauranteRepositoryMock = new Mock<IRestaurantRepository>();
            _mapperMock = new Mock<IMapper>();
            _restaurantePratoService = new RestaurantePratoService(_restaurantePratoRepositoryMock.Object, _restauranteRepositoryMock.Object, _mapperMock.Object);
        }

        #region sucesso
        [Test]
        public async Task CadastrarPratoRestaurante_ShouldInsertRestaurantePrato()
        {
            // Arrange
            var restaurantePratoInputModel = new RestaurantePratoInputModel();
            var restaurante = new Restaurante();
            var restaurantePrato = new RestaurantePrato();
            _restauranteRepositoryMock.Setup(r => r.ObterPorIdAsync(restaurantePratoInputModel.RestauranteId)).ReturnsAsync(restaurante);
            _mapperMock.Setup(m => m.Map<RestaurantePrato>(restaurantePratoInputModel)).Returns(restaurantePrato);

            // Act
            await _restaurantePratoService.CadastrarPratoRestaurante(restaurantePratoInputModel);

            // Assert
            _restaurantePratoRepositoryMock.Verify(r => r.InserirAsync(restaurantePrato), Times.Once);
        }

        [Test]
        public async Task ObterRestaurantePrato_ShouldReturnRestaurantePratoViewModel()
        {
            // Arrange
            var restaurantePrato = new RestaurantePrato();
            var restaurantePratoViewModel = new RestaurantePratoViewModel();
            _restaurantePratoRepositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(restaurantePrato);
            _mapperMock.Setup(m => m.Map<RestaurantePratoViewModel>(restaurantePrato)).Returns(restaurantePratoViewModel);

            // Act
            var result = await _restaurantePratoService.ObterRestaurantePrato(1);

            // Assert
            Assert.AreEqual(restaurantePratoViewModel, result);
        }
        [Test]
        public async Task ObterTodosRestaurantePrato_ShouldReturnRestaurantePratoViewModelList()
        {
            // Arrange
            var restaurantePratos = new List<RestaurantePrato>();
            var restaurantePratosViewModel = new List<RestaurantePratoViewModel>();

            _restaurantePratoRepositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(restaurantePratos);
            _mapperMock.Setup(m => m.Map<List<RestaurantePratoViewModel>>(restaurantePratos)).Returns(restaurantePratosViewModel);

            // Act
            var result = await _restaurantePratoService.ObterTodosRestaurantePrato();

            // Assert
            Assert.AreEqual(restaurantePratosViewModel, result);
        }

        #endregion

    }
}
