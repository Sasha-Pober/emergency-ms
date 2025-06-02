using System.Security.Cryptography;

namespace Domain.Interfaces;

public interface IRsaKeyProvider
{
    RSA GetPrivateKey();
}