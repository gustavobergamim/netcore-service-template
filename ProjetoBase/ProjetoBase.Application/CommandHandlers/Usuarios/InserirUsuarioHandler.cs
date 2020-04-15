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
    public class InserirUsuarioHandler : IHandler<InserirUsuarioCommand, CommandResult>
    {
        private readonly IQueries<Usuario> _query;
        private readonly IRepository<Usuario> _repository;
        private readonly IUnitOfWork _uow;

        public InserirUsuarioHandler(IQueries<Usuario> query, IRepository<Usuario> repository, IUnitOfWork uow)
        {
            _query = query;
            _repository = repository;
            _uow = uow;
        }

        public async Task<CommandResult> Handle(InserirUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (await _query.Any(u => u.Nome == request.Nome))
            {
                return CommandResultFactory.DuplicatedResult<Usuario>();
            }

            var usuario = (Usuario)request;
            await _repository.InsertAsync(usuario);
            await _uow.CommitAsync();

            var result = (UsuarioResult)usuario;
            return CommandResultFactory.InsertSucessResult<Usuario>(result);
        }
    }
}
