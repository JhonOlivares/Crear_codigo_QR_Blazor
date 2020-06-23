using System;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace CodigoQRBlazor.Data
{
    public class CodigoQR
    {
        public string Texto { get; set; }
        public string CodigoQRstr { get; set; }

        public void QRGenerator()
        {
            CodigoQRstr = "";
            if (!string.IsNullOrEmpty(Texto))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QRCodeGenerator codeGenerator = new QRCodeGenerator();
                    QRCodeData coreData = codeGenerator.CreateQrCode(Texto, QRCodeGenerator.ECCLevel.Q);
                    QRCode codigoQR = new QRCode(coreData);
                    using (Bitmap bitmap = codigoQR.GetGraphic(20))
                    {
                        bitmap.Save(ms, ImageFormat.Png);
                        CodigoQRstr = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
    }
}
