using System.Security.Cryptography;
using Gallery.Application.Interfaces.Authentication;

namespace Gallery.Infrastructure.Authentication;

public class TokenGenerator : ITokenGenerator
{
    public string Generate() => Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
}
