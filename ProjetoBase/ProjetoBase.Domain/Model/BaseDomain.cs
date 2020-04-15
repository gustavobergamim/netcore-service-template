namespace ProjetoBase.Domain.Model
{
    public abstract class BaseDomain : IDomainEntity
    {
        public decimal Id { get; private set; }
        public string Descricao { get; private set; }

        protected BaseDomain() { }
        protected BaseDomain(decimal id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
