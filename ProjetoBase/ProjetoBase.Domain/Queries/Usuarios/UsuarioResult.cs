using System;
using ProjetoBase.Domain.Model.Usuarios;

namespace ProjetoBase.Domain.Queries.Usuarios
{
    public class UsuarioResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator UsuarioResult(Usuario usuario)
        {
            return new UsuarioResult { Id = usuario.Id, Nome = usuario.Nome };
        }
    }
}
