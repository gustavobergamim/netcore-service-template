using System;
using ProjetoBase.Domain.Commands.Usuarios;

namespace ProjetoBase.Domain.Model.Usuarios
{
    public class Usuario : IDomainEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        protected Usuario()
        {
            //Empty constructor for EF
        }

        public Usuario(string nome)
            : this(Guid.NewGuid(), nome)
        {
            
        }

        public Usuario(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void Alterar(AlterarUsuarioCommand command)
        {
            Nome = command.Nome;
        }

        public static explicit operator Usuario(InserirUsuarioCommand command)
        {
            return new Usuario(command.Nome);
        }

        public static explicit operator Usuario(AlterarUsuarioCommand command)
        {
            return new Usuario(command.Id, command.Nome);
        }
    }
}
