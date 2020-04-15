using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Application.Queries;
using ProjetoBase.Domain.Commands.Usuarios;
using ProjetoBase.Domain.Model.Usuarios;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoBase.WebApi.Model;

namespace ProjetoBase.WebApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly IQueries<Usuario> _query;

        public UsuarioController(IMediator bus, IQueries<Usuario> query) : base(bus)
        {
            _query = query;
        }

        /// <summary>
        /// Lista os usuários cadastrados no sistema
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Listagem de usuários</response>
        [HttpGet, ProducesResponseType(200)]
        public async Task<List<Usuario>> Listar()
        {
            return await _query.List();
        }

        /// <summary>
        /// Obtém o usuário pelo seu Id
        /// </summary>
        /// <returns>Usuário solicitado</returns>
        /// <response code="200">Usuário solicitado ou nulo</response>
        [HttpGet("{id}"), ProducesResponseType(200)]
        public async Task<Usuario> Listar(Guid id)
        {
            return await _query.FindById(id);
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="inserirUsuario">Objeto com o nome do usuário para inclusão</param>
        /// <returns>Id e nome do usuário criado</returns>
        /// <response code="200">Usuário criado</response>
        /// <response code="400">Erros de validação dos parâmetros para inclusão do usuário</response>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommand inserirUsuario)
        {
            return await ExecuteCommand(inserirUsuario);
        }

        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="alterarUsuario">Objeto com o id e nome do usuário para alteração</param>
        /// <returns>Id e nome do usuário alterado</returns>
        /// <response code="200">Usuário alterado</response>
        /// <response code="400">Erros de validação dos parâmetros para alteração do usuário</response>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Alterar([FromBody] AlterarUsuarioCommand alterarUsuario)
        {
            return await ExecuteCommand(alterarUsuario);
        }
    }
}
