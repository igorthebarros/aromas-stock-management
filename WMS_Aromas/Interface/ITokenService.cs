using Aromas.Domain.Entities;

namespace Aromas.App.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}