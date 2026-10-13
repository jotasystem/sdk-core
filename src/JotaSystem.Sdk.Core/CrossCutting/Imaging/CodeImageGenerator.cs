using ZXing;
using ZXing.Common;
using ZXing.OneD;
using QRCoder;

namespace JotaSystem.Sdk.Core.CrossCutting.Imaging
{
    public static class CodeImageGenerator
    {
        public static byte[] Barcode128(string codigo)
        {
            var hints = new Dictionary<EncodeHintType, object>
            {
                [EncodeHintType.MARGIN] = 0
            };

            var matrix = new Code128Writer().encode(codigo, BarcodeFormat.CODE_128, 800, 200, hints);

            return PngEncoder.EncodeMonochrome(matrix.Width, matrix.Height, (x, y) => matrix[x, y]);
        }

        public static byte[] QRCode(string texto)
        {
            using var generator = new QRCodeGenerator();
            using var qrData = generator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);

            return new PngByteQRCode(qrData).GetGraphic(10, drawQuietZones: false);
        }
    }
}
