using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Repository.MySQL
{
    public class ProductConverter
    {
        public static BitmapImage ToBitmapImage(byte[] dataBlob)
        {
            MemoryStream strmImg = new MemoryStream(dataBlob);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = strmImg;
            bitmapImage.DecodePixelWidth = 200;
            bitmapImage.EndInit();
            return bitmapImage;
        }

        public static byte[] ToBytesArray(BitmapImage bitmapImage)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            MemoryStream memoryStream = new MemoryStream();
            encoder.Save(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
