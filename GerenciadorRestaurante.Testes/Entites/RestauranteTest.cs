using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Testes.Entites
{
    public class RestauranteTest
    {
        [TestFixture]
        public class RestauranteTests
        {
            [Test]
            public void Restaurante_CriarInstancia_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();

                // Act

                // Assert
                Assert.IsNotNull(restaurante);
            }

            [Test]
            public void Restaurante_DefinirNome_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();
                var nome = "Restaurante A";

                // Act
                restaurante.Nome = nome;

                // Assert
                Assert.AreEqual(nome, restaurante.Nome);
            }

            [Test]
            public void Restaurante_DefinirDescricao_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();
                var descricao = "Restaurante de comida italiana";

                // Act
                restaurante.Descricao = descricao;

                // Assert
                Assert.AreEqual(descricao, restaurante.Descricao);
            }

            [Test]
            public void Restaurante_DefinirEndereco_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();
                var endereco = new Endereco(Logradouro: "Rua A", Numero: "123", 
                                                    Complemento: "Apto 101", Bairro: "Centro", Cidade: "São Paulo",
                                                    Estado: "SP", Cep: "12345-678");
              
                // Act
                restaurante.Endereco = endereco;

                // Assert
                Assert.AreEqual(endereco, restaurante.Endereco);
            }

            [Test]
            public void Restaurante_DefinirMesas_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();
                var mesas = new List<Mesa>
            {
                new Mesa { Numero = 1, Capacidade = 4 },
                new Mesa { Numero = 2, Capacidade = 6 },
                new Mesa { Numero = 3, Capacidade = 2 }
            };

                // Act
                restaurante.Mesas = mesas;

                // Assert
                Assert.AreEqual(mesas, restaurante.Mesas);
            }

            [Test]
            public void Restaurante_DefinirReservas_Valido()
            {
                // Arrange
                var restaurante = new Restaurante();
                var reservas = new List<Reserva>
            {
                new Reserva { DataReserva = new DateTime(2022, 1, 1), QuantidadePessoas = 2 },
                new Reserva { DataReserva = new DateTime(2022, 1, 2), QuantidadePessoas = 4 },
                new Reserva { DataReserva = new DateTime(2022, 1, 3), QuantidadePessoas = 6 }
            };

                // Act
                restaurante.Reservas = reservas;

                // Assert
                Assert.AreEqual(reservas, restaurante.Reservas);
            }

        }
    }
}
