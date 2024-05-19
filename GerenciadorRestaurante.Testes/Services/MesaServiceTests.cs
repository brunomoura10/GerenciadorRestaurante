using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;
using Moq;

namespace GerenciadorRestaurante.Testes.Services
{
    [TestFixture]
    public class MesaServiceTests
    {
        private MesaService _mesaService;
        private Mock<IMesaRepository> _mesaRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _mesaRepositoryMock = new Mock<IMesaRepository>();
            _mapperMock = new Mock<IMapper>();
            _mesaService = new MesaService(_mesaRepositoryMock.Object, _mapperMock.Object);
        }

        #region Sucesso
        [Test]
        public async Task CadastrarMesa_ShouldInsertMesa()
        {
            // Arrange
            var mesaInputModel = new MesaInputModel();
            var mesa = new Mesa();
            _mapperMock.Setup(m => m.Map<Mesa>(mesaInputModel)).Returns(mesa);

            // Act
            await _mesaService.CadastrarMesa(mesaInputModel);

            // Assert
            _mesaRepositoryMock.Verify(r => r.InserirAsync(mesa), Times.Once);
        }

        [Test]
        public async Task ExcluirMesa_ShouldDeleteMesa()
        {
            // Arrange
            var id = 1;
            var mesa = new Mesa();
            _mesaRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(mesa);

            // Act
            await _mesaService.ExcluirMesa(id);

            // Assert
            _mesaRepositoryMock.Verify(r => r.ExcluirAsync(mesa), Times.Once);
        }
        #endregion

        #region Falha
        [Test]
        public void ExcluirMesa_MesaNaoEncontradaException()
        {
            // Arrange
            var id = 1;
            _mesaRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Mesa)null);

            // Act
            var exception = Assert.ThrowsAsync<MesaNaoEncontradaException>(() => _mesaService.ExcluirMesa(id));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Mesa não encontrada na base de dados"));
        }

        #endregion
    }
}