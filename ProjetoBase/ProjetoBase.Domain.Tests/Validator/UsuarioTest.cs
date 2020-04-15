using System;
using ProjetoBase.Domain.Commands.Usuarios;
using Xunit;

namespace ProjetoBase.Domain.Tests.Validator
{
    public class UsuarioTest
    {
        [Theory]
        [InlineData("Gustavo")]
        [InlineData("Arthur")]
        [InlineData("Jean")]
        public void InserirUsuarioComNomeValido(string nome)
        {
            var command = new InserirUsuarioCommand(nome);
            var validator = new InserirUsuarioValidator();
            var result = validator.Validate(command);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("A")]
        [InlineData("Ab")]
        public void InserirUsuarioComNomeInvalido(string nome)
        {
            var command = new InserirUsuarioCommand(nome);
            var validator = new InserirUsuarioValidator();
            var result = validator.Validate(command);
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => String.Equals("Nome", e.PropertyName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("A")]
        [InlineData("Ab")]
        public void AlterarUsuarioComNomeInvalido(string nome)
        {
            var command = new AlterarUsuarioCommand(Guid.NewGuid(), nome);
            var validator = new AlterarUsuarioValidator();
            var result = validator.Validate(command);
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => String.Equals("Nome", e.PropertyName));
        }
    }
}
