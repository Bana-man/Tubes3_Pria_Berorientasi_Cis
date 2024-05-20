using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Tubes3GUI
{
    public class Utility
    {

        public static List<char> ConvertImageToBinaryIntegers(Bitmap image)
        {
            // Convert the Bitmap to a byte array
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                imageBytes = ms.ToArray();
            }

            List<char> characters = new List<char>();

            // Process each byte in the byte array
            foreach (byte b in imageBytes)
            {
                // Convert the byte to its binary representation
                string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');

                // Split the binary string into 8-bit segments and convert to integers
                for (int i = 0; i < binaryString.Length; i += 8)
                {
                    string byteSegment = binaryString.Substring(i, 8);
                    int intValue = Convert.ToInt32(byteSegment, 2);
                    characters.Add((char)intValue);
                }
            }

            return characters;
        }
    }
}