using System.Security.Cryptography;
using System.Text;

namespace Lab2;

public static class Dsa
{
    public static void UseDsa()
    {
        Console.Write("Textul pentru a fi semnat: ");
        string originalText = Console.ReadLine() ?? string.Empty;

        var keyProvider = new DSACryptoServiceProvider();
        DSAParameters privateKey = keyProvider.ExportParameters(true);
        DSAParameters publicKey = keyProvider.ExportParameters(false);

        var bytes = Encoding.UTF8.GetBytes(originalText);
        var signature = SignData(bytes, privateKey);
        var verifySignature = VerifySignature(bytes, signature, publicKey);

        Console.WriteLine("Textul este semnat corect: " + verifySignature);
    }

    public static byte[] SignData(byte[] dataToSign, DSAParameters privateKey)
    {
        using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
        {
            dsa.ImportParameters(privateKey);
            return dsa.SignData(dataToSign);
        }
    }


    public static bool VerifySignature(byte[] dataToVerify, byte[] signature, DSAParameters publicKey)
    {
        using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
        {
            dsa.ImportParameters(publicKey);
            return dsa.VerifyData(dataToVerify, signature);
        }
    }

}
