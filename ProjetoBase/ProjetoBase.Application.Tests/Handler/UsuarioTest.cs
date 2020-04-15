using System;
using System.Threading;
using NSubstitute;
using ProjetoBase.Application.CommandHandlers.Usuarios;
using ProjetoBase.Application.Queries;
using ProjetoBase.Application.Repositories;
using ProjetoBase.Application.Tests.InputData;
using ProjetoBase.Domain.Commands.Usuarios;
using ProjetoBase.Domain.Model.Usuarios;
using ProjetoBase.Domain.Queries.Usuarios;
using Xunit;

namespace ProjetoBase.Application.Tests.Handler
{
    public class UsuarioTest
    {
        private readonly IQueries<Usuario> _query;
        private readonly IRepository<Usuario> _repository;
        private readonly IUnitOfWork _uow;

        public UsuarioTest()
        {
            _query = Substitute.For<IQueries<Usuario>>();
            _repository = Substitute.For<IRepository<Usuario>>();
            _uow = Substitute.For<IUnitOfWork>();
        }

        [Theory]
        [InlineData("Gustavo")]
        [InlineData("Arthur")]
        [InlineData("Jean")]
        public async void InserirUsuario(string nome)
        {
            var command = new InserirUsuarioCommand(nome);
            var handler = new InserirUsuarioHandler(_query, _repository, _uow);
            var result = await handler.Handle(command, CancellationToken.None);
            var model = result.GetModel<UsuarioResult>();
            Assert.True(result.IsValid);
            Assert.True(model.Id != Guid.Empty);
            Assert.Equal(nome, model.Nome);
        }

        [Theory]
        [ClassData(typeof(AlterarUsuarioClassData))]
        public async void AlterarUsuario(Guid id, string nome)
        {
            var command = new AlterarUsuarioCommand(id, nome);
            var handler = new AlterarUsuarioHandler(_query, _repository, _uow);
            _query.FindById(id).Returns(new Usuario(id, nome));
            var result = await handler.Handle(command, CancellationToken.None);
            var model = result.GetModel<UsuarioResult>();
            Assert.True(result.IsValid);
            Assert.Equal(id, model.Id);
            Assert.Equal(nome, model.Nome);
        }
    }
}
