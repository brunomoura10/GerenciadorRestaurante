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
using GerenciadorRestaurante.Core.ValueObjects;

namespace GerenciadorRestaurante.Testes.Entites
{
    [TestFixture]
    public class ClienteServiceTests
    {
        private Mock<IClienteRepository> _clienteRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private ClienteService _clienteService;

        [SetUp]
        public void Setup()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _mapperMock = new Mock<IMapper>();
            _clienteService = new ClienteService(_clienteRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CadastrarCliente_DeveInserirCliente()
        {
            var clienteInputModel = new ClienteInputModel
            {
                Nome = "Teste Cliente",
                Senha = "senha123",
                Telefone = "123456789",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Teste", "123", "", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345-678"),
                Tipo = TipoUsuario.cliente
            };

            var cliente = new Cliente
            {
                Nome = "Teste Cliente",
                Senha = "senha123",
                Telefone = "123456789",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Teste", "123", "", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345-678"),
                Tipo = TipoUsuario.cliente
            };

            _mapperMock.Setup(m => m.Map<Cliente>(clienteInputModel)).Returns(cliente);

            await _clienteService.CadastrarCliente(clienteInputModel);

            _clienteRepositoryMock.Verify(r => r.InserirAsync(cliente), Times.Once);
        }

        [Test]
        public async Task AtualizarCliente_QuandoClienteExiste_DeveAtualizarCliente()
        {
            var clienteInputModel = new ClienteInputModel
            {
                Nome = "Teste Cliente Atualizado",
                Senha = "senha456",
                Telefone = "987654321",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Atualizada", "456", "Apt 2", "Bairro Atualizado", "Cidade Atualizada", "Estado Atualizado", "98765-432"),
                Tipo = TipoUsuario.cliente
            };

            var cliente = new Cliente
            {
                Id = 1,
                Nome = "Teste Cliente",
                Senha = "senha123",
                Telefone = "123456789",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Teste", "123", "", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345-678"),
                Tipo = TipoUsuario.cliente
            };

            _clienteRepositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(cliente);
            _mapperMock.Setup(m => m.Map(clienteInputModel, cliente)).Verifiable();

            await _clienteService.AtualizarCliente(1, clienteInputModel);

            _mapperMock.Verify(m => m.Map(clienteInputModel, cliente), Times.Once);
            _clienteRepositoryMock.Verify(r => r.AtualizarAsync(cliente), Times.Once);
        }

        [Test]
        public async Task ConsultarClientePorId_QuandoClienteExiste_DeveRetornarClienteViewModel()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nome = "Teste Cliente",
                Senha = "senha123",
                Telefone = "123456789",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Teste", "123", "", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345-678"),
                Tipo = TipoUsuario.cliente
            };

            var clienteViewModel = new ClienteViewModel
            {
                Nome = "Teste Cliente",
                Senha = "senha123",
                Telefone = "123456789",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Endereco = new Endereco("Rua Teste", "123", "", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345-678"),
                Tipo = TipoUsuario.cliente
            };

            _clienteRepositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(cliente);
            _mapperMock.Setup(m => m.Map<ClienteViewModel>(cliente)).Returns(clienteViewModel);

            var result = await _clienteService.ConsultarClientePorId(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(clienteViewModel.Nome, result.Nome);
        }

        [Test]
        public async Task ConsultarTodosClientes_DeveRetornarListaDeClienteViewModel()
        {
            var clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Cliente 1", Endereco = new Endereco("Rua 1", "1", "", "Bairro 1", "Cidade 1", "Estado 1", "11111-111") },
            new Cliente { Id = 2, Nome = "Cliente 2", Endereco = new Endereco("Rua 2", "2", "", "Bairro 2", "Cidade 2", "Estado 2", "22222-222") }
        };

            var clienteViewModels = new List<ClienteViewModel>
        {
            new ClienteViewModel { Nome = "Cliente 1", Endereco = new Endereco("Rua 1", "1", "", "Bairro 1", "Cidade 1", "Estado 1", "11111-111") },
            new ClienteViewModel { Nome = "Cliente 2", Endereco = new Endereco("Rua 2", "2", "", "Bairro 2", "Cidade 2", "Estado 2", "22222-222") }
        };

            _clienteRepositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(clientes);
            _mapperMock.Setup(m => m.Map<IEnumerable<ClienteViewModel>>(clientes)).Returns(clienteViewModels);

            var result = await _clienteService.ConsultarTodosClientes();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task DeletarCliente_QuandoClienteExiste_DeveExcluirCliente()
        {
            var cliente = new Cliente { Id = 1, Nome = "Cliente a deletar", Endereco = new Endereco("Rua", "123", "", "Bairro", "Cidade", "Estado", "12345-678") };

            _clienteRepositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(cliente);

            await _clienteService.DeletarCliente(1);

            _clienteRepositoryMock.Verify(r => r.ExcluirAsync(cliente), Times.Once);
        }
    }

}
