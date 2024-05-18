using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Core.Entites;

namespace GerenciadorRestaurante.Testes.Entites
{
    public class PratoTest
    {
        [TestFixture]
        public class PratoTests
        {
            [Test]
            public void Prato_CriarInstancia_Valido()
            {
                // Arrange
                var prato = new Prato();

                // Act

                // Assert
                Assert.That(prato, Is.Not.Null);
            }

            [Test]
            public void Prato_DefinirNome_Valido()
            {
                // Arrange
                var prato = new Prato();
                var nome = "Macarrão à pistache";

                // Act
                prato.Nome = nome;

                // Assert
                Assert.That(prato.Nome, Is.EqualTo(nome));
            }

            [Test]
            public void Prato_DefinirDescricao_Valido()
            {
                // Arrange
                var prato = new Prato();
                var descricao = "Acompanha pistache";

                // Act
                prato.Descricao = descricao;

                // Assert
                Assert.That(prato.Descricao, Is.EqualTo(descricao));
            }
        }
    }
}