using System.Threading;
using System.Threading.Tasks;
using ProjetoBase.Application.CommandHandlers.Core;
using ProjetoBase.Application.Queries;
using ProjetoBase.Application.Repositories;
using ProjetoBase.Domain.Commands;
using ProjetoBase.Domain.Commands.Usuarios;
using ProjetoBase.Domain.Model.Usuarios;
using ProjetoBase.Domain.Queries.Usuarios;

namespace ProjetoBase.Application.CommandHandlers.Usuarios
{
    public class AlterarUsuarioHandler : IHandler<AlterarUsuarioCommand, CommandResult>
    {
        private readonly IQueries<Usuario> _query;
        private readonly IRepository<Usuario> _repository;
        private readonly IUnitOfWork _uow;

        public AlterarUsuarioHandler(IQueries<Usuario> query, IRepository<Usuario> repository, IUnitOfWork uow)
        {
            _query = query;
            _repository = repository;
            _uow = uow;
        }

        public async Task<CommandResult> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _query.FindById(request.Id);
            if (usuario == null)
            {
                return CommandResultFactory.NotFoundResult<Usuario>();
            }
            if (await _query.Any(u => u.Id != request.Id && u.Nome == request.Nome))
            {
                return CommandResultFactory.DuplicatedResult<Usuario>();
            }

            usuario.Alterar(request);
            await _repository.UpdateAsync(usuario);
            await _uow.CommitAsync();

            var result = (UsuarioResult)usuario;
            return CommandResultFactory.UpdateSucessResult<Usuario>(result);
        }
    }
}
