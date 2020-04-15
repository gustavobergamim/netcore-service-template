namespace ProjetoBase.Domain.Messages
{
    public struct ValidationMessages
    {
        public const string RequiredField = "O campo {PropertyName} é obrigatório.";
        public const string MinLength = "O campo {PropertyName} deve ter pelo menos {MinLength} caracteres.";
        public const string MaxLength = "O campo {PropertyName} possui limite máximo {MaxLength} caracteres";
    }

}