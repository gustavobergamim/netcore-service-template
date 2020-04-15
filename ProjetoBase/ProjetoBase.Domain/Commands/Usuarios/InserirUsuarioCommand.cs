
namespace ProjetoBase.Domain.Commands.Usuarios
{
    public class InserirUsuarioCommand : ICommand<CommandResult>
    {
        public string Nome { get; set; }

        public InserirUsuarioCommand()
        {
            //TODO System.Text.Json
            /*
             * System.Text.Json ainda nao suporta tipos imutaveis
             * e precisa de construtor default para desserializacao
             */
        }

        public InserirUsuarioCommand(string nome)
        {
            Nome = nome;
        }
    }
}
