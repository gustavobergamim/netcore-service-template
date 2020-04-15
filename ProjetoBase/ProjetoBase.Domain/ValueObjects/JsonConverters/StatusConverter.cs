namespace ProjetoBase.Domain.ValueObjects.JsonConverters
{
    /*
     * Especialização criada apenas para acionamento dos operadores
     */
    public class StatusConverter : BooleanConverter<Status>
    {
        protected override Status ConvertToModel(bool? value)
        {
            return value.HasValue ? (Status) value.Value : null;
        }

        protected override bool? ConvertFromModel(Status value)
        {
            return value;
        }
    }
}
