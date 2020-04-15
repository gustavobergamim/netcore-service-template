using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjetoBase.Application.Tests.InputData
{
    internal class AlterarUsuarioClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{ new Guid("fae55a26-d1bd-4b17-b4ad-0c6bed131a89"), "Gustavo" };
            yield return new object[] { new Guid("f41fcefa-b3ea-4427-ad1c-2ac3bcc73807"), "Arthur" };
            yield return new object[] { new Guid("bf0709fc-9aa2-46c3-94f1-53902efcc5a7"), "Jean" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
