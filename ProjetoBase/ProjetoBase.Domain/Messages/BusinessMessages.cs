using System;
using System.Collections.Generic;
using ProjetoBase.Domain.Model.Usuarios;

namespace ProjetoBase.Domain.Messages
{
    public struct BusinessMessages
    {
        public static string GenericSucess() => "Operação realizada com sucesso.";

        public static string InsertSucess<T>() => $"{GetMessages<T>().EntityName} cadastrad{GetMessages<T>().GetGender()} com sucesso.";
        public static string UpdateSucess<T>() => $"{GetMessages<T>().EntityName} alterad{GetMessages<T>().GetGender()} com sucesso.";
        public static string DeleteSucess<T>() => $"{GetMessages<T>().EntityName} excluíd{GetMessages<T>().GetGender()} com sucesso.";
        public static string DuplicatedError<T>() => $"Já existe um registro de {GetMessages<T>().EntityName} cadastrad{GetMessages<T>().GetGender()} {GetMessages<T>().Duplicated}.";
        public static string NotFoundError<T>() => $"{GetMessages<T>().EntityName} não encontrad{GetMessages<T>().GetGender()}.";

        private static DomainMessages GetMessages<T>() => DomainMessages.Get<T>();


        internal class DomainMessages
        {
            public enum Gender { Male = 'o', Female = 'a' }

            public string EntityName { get; }
            public Gender EntityGender { get; }

            public string Duplicated { get; protected set; }

            public DomainMessages(string entityName, Gender entityGender)
            {
                EntityName = entityName;
                EntityGender = entityGender;
            }

            public char GetGender()
            {
                return (char) EntityGender;
            }

            private static IDictionary<Type, DomainMessages> Messages { get; } = new Dictionary<Type, DomainMessages>
            {
                { typeof(Usuario), new DomainMessages("Usuário", Gender.Male) { Duplicated = "com este Nome" } }
            };

            public static DomainMessages Get<T>() => 
                Messages.ContainsKey(typeof(T)) 
                    ? Messages[typeof(T)] 
                    : throw new ArgumentOutOfRangeException($"Domain messages not found for type {typeof(T).FullName}");
        }
    }
}