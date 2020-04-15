using System.Text.Json.Serialization;
using ProjetoBase.Domain.ValueObjects.JsonConverters;

namespace ProjetoBase.Domain.ValueObjects
{
    [JsonConverter(typeof(StatusConverter))]
    public class Status : ValueObject<Status>
    {
        public char Valor { get; protected set; }

        public Status(bool ativado)
        {
            Valor = ativado ? (char)ValueStatusEnum.Ativo : (char)ValueStatusEnum.Inativo;
        }
        protected Status() { }

        public static implicit operator char(Status status)
        {
            return status.Valor;
        }

        public static implicit operator bool(Status status)
        {
            return status is null || status.Valor == (char)ValueStatusEnum.Ativo;
        }

        public static implicit operator Status(bool status)
        {
            return new Status(status);
        }

        protected override bool EqualsCore(Status other)
        {
            return other.Valor == Valor;
        }

        protected override int GetHashCodeCore()
        {
            return Valor.GetHashCode();
        }

        private enum ValueStatusEnum
        {
            Ativo = 'A',
            Inativo = 'I'
        }
    }
}