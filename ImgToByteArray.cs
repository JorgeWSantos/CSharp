using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biom
{
    class ImgToByteArray
    {
        //CONVERTE DE Image para byte[]
        private byte[] ImageToByteArray(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                stream.Read(bArray, 0, Convert.ToInt32(stream.Length));
                return bArray;
            }
        }
    }
}
