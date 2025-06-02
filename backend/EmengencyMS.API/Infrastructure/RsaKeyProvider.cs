using Domain.Interfaces;
using System.Security.Cryptography;

namespace Infrastructure;

public class RsaKeyProvider : IRsaKeyProvider
{
    public RSA GetPrivateKey()
    {
        var rsa = RSA.Create();

        var privateKeyBase64 = Environment.GetEnvironmentVariable("JWT_KEY");

        if (!string.IsNullOrEmpty(privateKeyBase64))
        {
            var privateKeyBytes = Convert.FromBase64String(privateKeyBase64);
            rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);
        }

        return rsa;
    }
}
