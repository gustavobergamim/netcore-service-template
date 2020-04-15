using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBase.Application.CommandHandlers.Core;
using ProjetoBase.Domain.Commands;
using ProjetoBase.Infra.Bus;

namespace ProjetoBase.Infra.IoC
{
    public static class CommandRegistry
    {
        public static void RegisterCommand(this IServiceCollection services)
        {
            var commandAssembly = typeof(CommandResult).GetTypeInfo().Assembly;
            AssemblyScanner
                .FindValidatorsInAssembly(commandAssembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddMediatR(typeof(CommandResult), typeof(IHandler<,>));
        }
    }
}
