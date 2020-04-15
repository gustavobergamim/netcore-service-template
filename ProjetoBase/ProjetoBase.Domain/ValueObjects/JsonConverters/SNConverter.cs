namespace ProjetoBase.Domain.ValueObjects.JsonConverters
{
    /*
     * Especialização criada apenas para acionamento dos operadores
     */
    public class SNConverter : BooleanConverter<SN>
    {
        protected override SN ConvertToModel(bool? value)
        {
            return value.HasValue ? (SN)value.Value : null;
        }

        protected override bool? ConvertFromModel(SN value)
        {
            return value;
        }
    }
}
