using System;
using System.Collections.Generic;
using System.Text;

static class Enkripsi
{
    private const string key = "dfjlsmcvbweoruxlf";
    private const int dateKey = 20854;
    private const int blockSize = 1024;
    private const int enumKey = 40;
    private static List<String> jenisKelaminEnum = new List<String>() { "Laki-Laki", "Perempuan" };
    private static List<String> statusPerkawinanEnum = new List<String>() { "Belum Menikah", "Menikah", "Cerai" };

    //static void Main()
    //{
    //    string plainText = "ing ngarsa sung tuladha, ing madya mbangun karsa, tut wuri handayani";

    //    string encryptedText = XorEncrypt(plainText);
    //    Console.WriteLine("Encrypted: " + encryptedText);

    //    string decryptedText = XorDecrypt(encryptedText);
    //    Console.WriteLine("Decrypted: " + decryptedText);
    //}

    public static string XorEncrypt(string inputString)
    {
        string matchKey = RepeatKeyToMatchBlockSize();
        List<string> blocks = GetBlocks(inputString);
        StringBuilder encryptedString = new StringBuilder();

        foreach (string block in blocks)
        {
            byte[] xorBlock = new byte[block.Length];
            for (int i = 0; i < block.Length; i++)
            {
                xorBlock[i] = (byte)(block[i] ^ key[i % key.Length]);
            }
            encryptedString.Append(Convert.ToBase64String(xorBlock) + " ");
        }

        return encryptedString.ToString().Trim();
    }

    public static string XorDecrypt(string encryptedString)
    {
        string matchKey = RepeatKeyToMatchBlockSize();
        List<string> encodedBlocks = GetBase64Blocks(encryptedString);
        StringBuilder decryptedString = new StringBuilder();

        foreach (string encodedBlock in encodedBlocks)
        {
            byte[] xorBlock = Convert.FromBase64String(encodedBlock);
            char[] decryptedBlock = new char[xorBlock.Length];
            for (int i = 0; i < xorBlock.Length; i++)
            {
                decryptedBlock[i] = (char)(xorBlock[i] ^ key[i % key.Length]);
            }
            decryptedString.Append(new string(decryptedBlock));
        }

        return decryptedString.ToString();
    }

    private static string RepeatKeyToMatchBlockSize()
    {
        StringBuilder repeatedKey = new StringBuilder();
        while (repeatedKey.Length < blockSize)
        {
            repeatedKey.Append(key);
        }
        return repeatedKey.ToString(0, blockSize);
    }

    private static List<string> GetBlocks(string input)
    {
        List<string> blocks = new List<string>();
        for (int i = 0; i < input.Length; i += blockSize)
        {
            int length;
            if (blockSize < input.Length - i) length = blockSize;
            else length = input.Length - i;

            blocks.Add(input.Substring(i, length));
        }
        return blocks;
    }

    private static List<string> GetBase64Blocks(string input)
    {
        List<string> blocks = new List<string>();
        string[] splitBlocks = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string block in splitBlocks)
        {
            blocks.Add(block);
        }
        return blocks;
    }

    public static string DateEncrypt(string date)
    {
        DateTime parsedDate = DateTime.Parse(date);
        DateTime encryptedDate = parsedDate.AddDays(dateKey);
        return encryptedDate.ToString("yyyy-MM-dd");
    }

    public static string DateDecrypt(string date)
    {
        DateTime parsedDate = DateTime.Parse(date);
        DateTime decryptedDate = parsedDate.AddDays(-dateKey);
        return decryptedDate.ToString("yyyy-MM-dd");
    }

    public static string EncryptOrDecrypt16DigitString(string input)
    {
        string matchKey = RepeatKeyToMatchBlockSize();
        char[] encryptedChars = new char[16];

        for (int i = 0; i < 16; i++)
        {
            int encryptedDigit = ((input[i] - '0') ^ (matchKey[i % key.Length] - '0'));
            encryptedChars[i] = (char)(encryptedDigit + '0');
        }

        return new string(encryptedChars);
    }

    public static string EncryptOrDecryptJenisKelamin(string input, bool encrypt)
    {
        int idx = jenisKelaminEnum.IndexOf(input);
        int encryptIdx = ((encrypt) ? idx + enumKey : idx - enumKey) % jenisKelaminEnum.Count;
        encryptIdx = (encryptIdx + jenisKelaminEnum.Count) % jenisKelaminEnum.Count;
        return jenisKelaminEnum[encryptIdx];
    }

    public static string EncryptOrDecryptStatusPerkawinan(string input, bool encrypt)
    {
        int idx = statusPerkawinanEnum.IndexOf(input);
        int encryptIdx = ((encrypt) ? idx + enumKey : idx - enumKey) % statusPerkawinanEnum.Count;
        encryptIdx = (encryptIdx + statusPerkawinanEnum.Count) % statusPerkawinanEnum.Count;
        return statusPerkawinanEnum[encryptIdx];
    }
}