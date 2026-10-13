using JotaSystem.Sdk.Core.CrossCutting.Imaging;
using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;

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

            var (width, height) = AssertPngValido(bytes);
            Assert.Equal(800, width);
            Assert.Equal(200, height);
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

            var (width, height) = AssertPngValido(bytes);
            Assert.True(width > 0);
            Assert.Equal(width, height);
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

        /// <summary>
        /// Valida assinatura, chunks e CRCs do PNG e retorna as dimensões declaradas no IHDR.
        /// </summary>
        private static (int Width, int Height) AssertPngValido(byte[] bytes)
        {
            byte[] signature = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];
            Assert.Equal(signature, bytes[..8]);

            int width = 0, height = 0;
            var chunks = new List<string>();
            using var idat = new MemoryStream();

            var offset = 8;
            while (offset < bytes.Length)
            {
                var length = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(offset));
                var type = Encoding.ASCII.GetString(bytes, offset + 4, 4);
                var data = bytes.AsSpan(offset + 8, length);
                var crc = BinaryPrimitives.ReadUInt32BigEndian(bytes.AsSpan(offset + 8 + length));

                Assert.Equal(Crc32(bytes.AsSpan(offset + 4, length + 4)), crc);
                chunks.Add(type);

                if (type == "IHDR")
                {
                    width = BinaryPrimitives.ReadInt32BigEndian(data);
                    height = BinaryPrimitives.ReadInt32BigEndian(data[4..]);
                }
                else if (type == "IDAT")
                {
                    idat.Write(data);
                }

                offset += 12 + length;
            }

            Assert.Equal("IHDR", chunks[0]);
            Assert.Contains("IDAT", chunks);
            Assert.Equal("IEND", chunks[^1]);
            Assert.True(width > 0);
            Assert.True(height > 0);

            // Os dados comprimidos precisam ser um zlib válido
            idat.Position = 0;
            using var zlib = new ZLibStream(idat, CompressionMode.Decompress);
            using var pixels = new MemoryStream();
            zlib.CopyTo(pixels);
            Assert.True(pixels.Length >= height);

            return (width, height);
        }

        private static uint Crc32(ReadOnlySpan<byte> data)
        {
            var crc = 0xFFFFFFFF;
            foreach (var b in data)
            {
                crc ^= b;
                for (int k = 0; k < 8; k++)
                    crc = (crc & 1) != 0 ? 0xEDB88320 ^ (crc >> 1) : crc >> 1;
            }

            return crc ^ 0xFFFFFFFF;
        }
    }
}
