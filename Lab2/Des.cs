using System.Security.Cryptography;
using System.Text;

namespace Lab2;

public static class Des
{
    public static void UseDes()
    {
        Console.Write("Textul de encriptat: ");
        string text = Console.ReadLine() ?? string.Empty;

        using (DESCryptoServiceProvider keyProvider = new DESCryptoServiceProvider())
        {
            keyProvider.GenerateKey();
            string encryptedText = EncryptData(text, keyProvider.Key);
            string decryptedText = DecryptData(keyProvider.Key, encryptedText);

            Console.WriteLine("Textul Criptat: " + encryptedText);
            Console.WriteLine("Textul Decriptat: " + decryptedText);
        }
    }

    public static string EncryptData(string textToEncrypt, byte[] key)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = key;
            des.IV = key;

            byte[] textBytes = Encoding.UTF8.GetBytes(textToEncrypt);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(textBytes, 0, textBytes.Length);
                    cs.FlushFinalBlock();
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string DecryptData(byte[] key, string dataToDecrypt)
    {
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            des.Key = key;
            des.IV = key;

            byte[] textBytes = Convert.FromBase64String(dataToDecrypt);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(textBytes, 0, textBytes.Length);
                    cs.FlushFinalBlock();
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }

}
