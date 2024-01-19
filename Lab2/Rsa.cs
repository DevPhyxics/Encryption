using System.Security.Cryptography;
using System.Text;

namespace Lab2;

public static class Rsa
{
    public static void UseRsa()
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        string publicKey = rsa.ToXmlString(false);
        string privateKey = rsa.ToXmlString(true);

        Console.WriteLine("Public key: " + publicKey);
        Console.WriteLine();
        Console.WriteLine("Private key: " + privateKey);
        Console.WriteLine();

        Console.Write("Introduceti text sa se encripteze: ");
        string textToEncrypt = Console.ReadLine() ?? string.Empty;

        var bytes = Encoding.UTF8.GetBytes(textToEncrypt);
        var encrypted = EncryptData(publicKey, bytes);

        var encryptedChars = Encoding.UTF8.GetString(encrypted);
        Console.WriteLine("\nEncrypted: " + encryptedChars);

        var decrypted = DecryptData(privateKey, encrypted);
        var decryptedChars = Encoding.UTF8.GetString(decrypted);

        Console.Write("\nDecrypted: " + decryptedChars);
        Console.ReadLine();
    }

    public static byte[] EncryptData(string publicKey, byte[] dataToEncrypt)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);

            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);

            return encryptedData;
        }
    }

    public static byte[] DecryptData(string privateKey, byte[] dataToDecrypt)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);
            return decryptedData;
        }
    }

}
