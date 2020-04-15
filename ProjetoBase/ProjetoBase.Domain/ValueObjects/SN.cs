using System.Text.Json.Serialization;
using ProjetoBase.Domain.ValueObjects.JsonConverters;

namespace ProjetoBase.Domain.ValueObjects
{
    [JsonConverter(typeof(SNConverter))]
    public class SN : ValueObject<SN>
    {
        public char Valor { get; protected set; }

        private enum ValueSNEnum
        {
            Sim = 'S',
            Nao = 'N'
        }

        public SN(bool sim)
        {
            Valor = sim ? (char)ValueSNEnum.Sim : (char)ValueSNEnum.Nao;
        }

        protected SN() { }

        public static implicit operator char(SN sn)
        {
            return sn.Valor;
        }

        public static implicit operator bool(SN sn)
        {
            return sn.Valor == (char)ValueSNEnum.Sim;
        }

        public static implicit operator SN(bool isChecked)
        {
            return new SN(isChecked);
        }

        protected override bool EqualsCore(SN other)
        {
            return other.Valor == Valor;
        }

        protected override int GetHashCodeCore()
        {
            return Valor.GetHashCode();
        }

    }
}
