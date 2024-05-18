using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Core.Entites;

namespace GerenciadorRestaurante.Testes.Entites
{
    public class MesaTest
    {
        [TestFixture]
        public class MesaTests
        {
            [Test]
            public void Mesa_CriarInstancia_Valido()
            {
                // Arrange
                var mesa = new Mesa();

                // Act

                // Assert
                Assert.That(mesa, Is.Not.Null);
            }

            [Test]
            public void Mesa_DefinirNumero_Valido()
            {
                // Arrange
                var mesa = new Mesa();
                int numero = 281;

                // Act
                mesa.Numero = numero;

                // Assert
                Assert.That(mesa.Numero, Is.EqualTo(numero));
            }

            [Test]
            public void Mesa_DefinirCapacidade_Valido()
            {
                // Arrange
                var mesa = new Mesa();
                int capacidade = 4;

                // Act
                mesa.Capacidade = capacidade;

                // Assert
                Assert.That(mesa.Capacidade, Is.EqualTo(capacidade));
            }
        }
    }
}