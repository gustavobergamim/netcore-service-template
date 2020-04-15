using System;
using Newtonsoft.Json;
using ProjetoBase.Domain.ValueObjects;
using Xunit;

namespace ProjetoBase.Domain.Tests.ValueObjects
{
    public class BooleanConverterTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BoolToStatusTest(bool value)
        {
            var objTeste = JsonConvert.DeserializeObject<ObjetoTeste>($"{{ \"Status\": \"{value}\" }}");
            Assert.NotNull(objTeste);
            Assert.True(value == objTeste.Status);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BoolToSNTest(bool value)
        {
            var objTeste = JsonConvert.DeserializeObject<ObjetoTeste>($"{{ \"Sn\": \"{value}\" }}");
            Assert.NotNull(objTeste);
            Assert.True(value == objTeste.Sn);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void StatusToBoolTest(bool value)
        {
            var objTeste = new ObjetoTeste { Status = new Status(value) };
            var result = JsonConvert.SerializeObject(objTeste);
            Assert.False(String.IsNullOrEmpty(result));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SNToBoolTest(bool value)
        {
            var objTeste = new ObjetoTeste { Sn = new SN(value) };
            var result = JsonConvert.SerializeObject(objTeste);
            Assert.False(String.IsNullOrEmpty(result));
        }

        internal class ObjetoTeste
        {
            public Status Status { get; set; }
            public SN Sn { get; set; }
        }
    }
}
