using JotaSystem.Sdk.Core.CrossCutting.Providers.Models;
using System.Text.Json;

namespace JotaSystem.Sdk.Core.Tests.CrossCutting.Providers
{
    public class PaymentCardTests
    {
        [Fact]
        public void MaskedNumber_DeveManterApenasBinEQuatroUltimosDigitos()
        {
            var card = new PaymentCard(Number: "4091 6886 2533 7641");

            Assert.Equal("409168******7641", card.MaskedNumber);
        }

        [Fact]
        public void MaskedNumber_DeveMascararNumerosCurtos()
        {
            var card = new PaymentCard(Number: "12345678");

            Assert.Equal("****5678", card.MaskedNumber);
        }

        [Fact]
        public void MaskedNumber_DeveSerNuloQuandoNaoHaNumero()
        {
            var card = new PaymentCard(Token: "card-token");

            Assert.Null(card.MaskedNumber);
            Assert.True(card.IsTokenized);
        }

        [Fact]
        public void Serializacao_NaoDeveExporNumeroNemCodigoDeSeguranca()
        {
            var card = new PaymentCard(
                Number: "4091688625337641",
                Holder: "Aline de Souza",
                ExpirationDate: "12/2035",
                SecurityCode: "333",
                Brand: "Visa");

            var json = JsonSerializer.Serialize(card);

            Assert.DoesNotContain("4091688625337641", json);
            Assert.DoesNotContain("333", json);
            Assert.Contains("409168******7641", json);
            Assert.Contains("Visa", json);
        }

        [Fact]
        public void ToString_NaoDeveExporNumeroNemCodigoDeSeguranca()
        {
            var card = new PaymentCard(Number: "4091688625337641", SecurityCode: "333", Brand: "Visa");

            var texto = card.ToString();

            Assert.DoesNotContain("4091688625337641", texto);
            Assert.DoesNotContain("333", texto);
            Assert.Contains("409168******7641", texto);
        }

        [Fact]
        public void Serializacao_DaCobranca_NaoDeveExporDadosSensiveisDoCartao()
        {
            var request = new PaymentProviderRequest(
                "cielo",
                "idempotency-key",
                "PED-00012",
                157.00m,
                "BRL",
                "credit_card",
                1,
                new PaymentCustomer("Aline de Souza", "12345678909"),
                Card: new PaymentCard(Number: "4091688625337641", SecurityCode: "333", Brand: "Visa"));

            var json = JsonSerializer.Serialize(request);

            Assert.DoesNotContain("4091688625337641", json);
            Assert.DoesNotContain("\"333\"", json);
            Assert.Contains("409168******7641", json);
        }
    }
}
