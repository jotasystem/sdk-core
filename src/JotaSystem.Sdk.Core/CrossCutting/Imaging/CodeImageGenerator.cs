using ZXing;
using ZXing.Common;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using QRCoder;

namespace JotaSystem.Sdk.Core.CrossCutting.Imaging
{
    public static class CodeImageGenerator
    {
        public static byte[] Barcode128(string codigo)
        {
            var writer = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 800,
                    Height = 200,
                    Margin = 0,
                    PureBarcode = true
                }
            };

            using Image<Rgba32> image = writer.Write(codigo);

            using var ms = new MemoryStream();
            image.SaveAsPng(ms);

            return ms.ToArray();
        }

        public static byte[] QRCode(string texto)
        {
            using var generator = new QRCodeGenerator();
            using var qrData = generator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);

            int scale = 10;
            int size = qrData.ModuleMatrix.Count;

            using var image = new Image<Rgba32>(size * scale, size * scale);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    var color = qrData.ModuleMatrix[y][x]
                        ? new Rgba32(0, 0, 0)
                        : new Rgba32(255, 255, 255);

                    for (int dy = 0; dy < scale; dy++)
                    {
                        for (int dx = 0; dx < scale; dx++)
                        {
                            image[x * scale + dx, y * scale + dy] = color;
                        }
                    }
                }
            }

            using var ms = new MemoryStream();
            image.SaveAsPng(ms);

            return ms.ToArray();
        }
    }
}
