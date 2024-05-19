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
    public class PratoServiceTests
    {
        private PratoService _pratoService;
        private Mock<IPratoRepository> _pratoRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _pratoRepositoryMock = new Mock<IPratoRepository>();
            _mapperMock = new Mock<IMapper>();
            _pratoService = new PratoService(_pratoRepositoryMock.Object, _mapperMock.Object);
        }

        #region Sucesso
        [Test]
        public async Task CadastrarPrato_ShouldInsertPrato()
        {
            // Arrange
            var pratoInputModel = new PratoInputModel();
            var prato = new Prato();
            _mapperMock.Setup(m => m.Map<Prato>(pratoInputModel)).Returns(prato);

            // Act
            await _pratoService.CadastrarPrato(pratoInputModel);

            // Assert
            _pratoRepositoryMock.Verify(r => r.InserirAsync(prato), Times.Once);
        }

        [Test]
        public async Task ExcluirPrato_ShouldDeletePrato()
        {
            // Arrange
            var id = 1;
            var prato = new Prato();
            _pratoRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(prato);

            // Act
            await _pratoService.ExcluirPrato(id);

            // Assert
            _pratoRepositoryMock.Verify(r => r.ExcluirAsync(prato), Times.Once);
        }
        #endregion

        #region Falha
        [Test]
        public void ExcluirPrato_PratoNaoEncontradoException()
        {
            // Arrange
            var id = 1;
            _pratoRepositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Prato)null);

            // Act
            var exception = Assert.ThrowsAsync<PratoNaoEncontradoException>(() => _pratoService.ExcluirPrato(id));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Prato não encontrado na base de dados"));
        }

        #endregion
    }
}