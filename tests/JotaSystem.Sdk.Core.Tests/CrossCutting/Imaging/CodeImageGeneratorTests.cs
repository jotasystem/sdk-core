using JotaSystem.Sdk.Core.CrossCutting.Imaging;
using SixLabors.ImageSharp;

namespace JotaSystem.Sdk.Core.Tests.CrossCutting.Imaging
{
    public class CodeImageGeneratorTests
    {
        [Fact]
        public void GerarBarcode128_DeveGerarPngValido()
        {
            // Arrange
            var codigo = "123456789012";

            // Act
            var bytes = CodeImageGenerator.Barcode128(codigo);

            // Assert
            Assert.NotNull(bytes);
            Assert.NotEmpty(bytes);

            // Verifica se é um PNG válido
            using var image = Image.Load(bytes);
            Assert.True(image.Width > 0);
            Assert.True(image.Height > 0);
        }

        [Fact]
        public void GerarQRCode_DeveGerarPngValido()
        {
            // Arrange
            var texto = "https://jotasystem.com.br";

            // Act
            var bytes = CodeImageGenerator.QRCode(texto);

            // Assert
            Assert.NotNull(bytes);
            Assert.NotEmpty(bytes);

            using var image = Image.Load(bytes);
            Assert.True(image.Width > 0);
            Assert.True(image.Height > 0);
        }

        [Theory]
        [InlineData("")]
        public void GerarBarcode128_EntradaInvalida_DeveLancarExcecao(string codigo)
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                CodeImageGenerator.Barcode128(codigo);
            });
        }
    }
}