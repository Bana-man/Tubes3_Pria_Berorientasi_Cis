using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace Tubes3GUI
{
    public class Utility
    {

        public static string ConvertImageToString(Bitmap image)
        {
            // Convert the Bitmap to a byte array
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                imageBytes = ms.ToArray();
            }

            StringBuilder stringBuilder = new StringBuilder();
            
            // Process each byte in the byte array
            for (var i = 0; i < imageBytes.Length; i += 1)
            {
                // Convert the byte to its binary representation
                char binaryString = (char) imageBytes[i];
                stringBuilder.Append(binaryString);

                // Split the binary string into 8-bit segments and convert to integers
                //for (int i = 0; i < binaryString.Length; i += 8)
                //{
                //    string byteSegment = binaryString.Substring(i, 8);
                //    int intValue = Convert.ToInt32(byteSegment, 2);
                //    stringBuilder.Append((char)intValue);
                //}
            }

            return stringBuilder.ToString();
        }

        public static string makeSubstringOfImage(Bitmap image)
        {
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                imageBytes = ms.ToArray();
            }
            StringBuilder stringBuilder = new StringBuilder();

            // Process each byte in the byte array
            for (var i = 15000; i < 15100; i += 1)
            {
                // Convert the byte to its binary representation
                char binaryString = (char)imageBytes[i];
                stringBuilder.Append(binaryString);

                // Split the binary string into 8-bit segments and convert to integers
                //for (int i = 0; i < binaryString.Length; i += 8)
                //{
                //    string byteSegment = binaryString.Substring(i, 8);
                //    int intValue = Convert.ToInt32(byteSegment, 2);
                //    stringBuilder.Append((char)intValue);
                //}
            }

            return stringBuilder.ToString();
        }

        public static Bitmap ConvertStringToImage(string str)
        {
            List<byte> imageBytes = new List<byte>();

            // Process each character in the string
            foreach (char c in str)
            {
                // Convert the character to its binary representation
                //string binaryString = Convert.ToString(c, 2).PadLeft(8, '0');

                // Convert the binary string to a byte
                byte b = Convert.ToByte(c);
                imageBytes.Add(b);
            }

            // Convert the byte array to a MemoryStream
            MemoryStream ms = new MemoryStream(imageBytes.ToArray());

            // Create a Bitmap from the MemoryStream
            Bitmap image = new Bitmap(ms);

            return image;
        }

        public static Bitmap LoadBitmapFromFile(string path)
        {
            return new Bitmap(path);
        }
    }
}