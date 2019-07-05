using System.Drawing;
using System.IO;

namespace biom
{
    class ByteToImg
    {
        //CONVERTE DE byte[] para Image
        private Image ByteToImage(byte[] foto)
        {
            using (var ms = new MemoryStream(foto))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
