using System;

namespace ProjetoBase.Domain.Commands.Usuarios
{
    public class AlterarUsuarioCommand : ICommand<CommandResult>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        
        public AlterarUsuarioCommand()
        {
            //TODO System.Text.Json
        }


        public AlterarUsuarioCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
