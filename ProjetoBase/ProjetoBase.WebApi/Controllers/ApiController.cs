using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Domain.Commands;
using ProjetoBase.WebApi.Model;

namespace ProjetoBase.WebApi.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator Bus;

        protected ApiController(IMediator bus)
        {
            Bus = bus;
        }

        protected async Task<IActionResult> ExecuteCommand<TResult>(ICommand<TResult> command) where TResult : CommandResult
        {
            if (command == null) return BadRequest("Invalid command.");
            ApiResult result = await Bus.Send(command);
            if (result.IsValid) return Ok(result);
            return BadRequest(result);
        }
    }
}
