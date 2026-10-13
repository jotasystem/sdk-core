using System.Buffers.Binary;
using System.IO.Compression;
using System.Text;

namespace JotaSystem.Sdk.Core.CrossCutting.Imaging
{
    /// <summary>
    /// Encoder PNG mínimo (escala de cinza, 8 bits) para imagens preto e branco,
    /// evitando dependência de bibliotecas de imagem de terceiros.
    /// </summary>
    internal static class PngEncoder
    {
        private static readonly byte[] Signature = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];
        private static readonly uint[] CrcTable = CreateCrcTable();

        public static byte[] EncodeMonochrome(int width, int height, Func<int, int, bool> isBlack)
        {
            using var output = new MemoryStream();
            output.Write(Signature);

            var header = new byte[13];
            BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(0), width);
            BinaryPrimitives.WriteInt32BigEndian(header.AsSpan(4), height);
            header[8] = 8;  // bit depth
            header[9] = 0;  // color type: grayscale
            header[10] = 0; // compression
            header[11] = 0; // filter
            header[12] = 0; // interlace
            WriteChunk(output, "IHDR", header);

            using (var raw = new MemoryStream())
            {
                using (var zlib = new ZLibStream(raw, CompressionLevel.Optimal, leaveOpen: true))
                {
                    var row = new byte[width + 1]; // byte 0 = filtro "None"
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                            row[x + 1] = isBlack(x, y) ? (byte)0x00 : (byte)0xFF;

                        zlib.Write(row);
                    }
                }

                WriteChunk(output, "IDAT", raw.ToArray());
            }

            WriteChunk(output, "IEND", []);

            return output.ToArray();
        }

        private static void WriteChunk(Stream output, string type, byte[] data)
        {
            Span<byte> buffer = stackalloc byte[4];

            BinaryPrimitives.WriteInt32BigEndian(buffer, data.Length);
            output.Write(buffer);

            var typeBytes = Encoding.ASCII.GetBytes(type);
            output.Write(typeBytes);
            output.Write(data);

            var crc = UpdateCrc(UpdateCrc(0xFFFFFFFF, typeBytes), data) ^ 0xFFFFFFFF;
            BinaryPrimitives.WriteUInt32BigEndian(buffer, crc);
            output.Write(buffer);
        }

        private static uint UpdateCrc(uint crc, byte[] data)
        {
            foreach (var b in data)
                crc = CrcTable[(crc ^ b) & 0xFF] ^ (crc >> 8);

            return crc;
        }

        private static uint[] CreateCrcTable()
        {
            var table = new uint[256];
            for (uint n = 0; n < 256; n++)
            {
                var c = n;
                for (int k = 0; k < 8; k++)
                    c = (c & 1) != 0 ? 0xEDB88320 ^ (c >> 1) : c >> 1;

                table[n] = c;
            }

            return table;
        }
    }
}
