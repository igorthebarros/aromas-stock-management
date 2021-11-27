using Aromas.Domain.Entities;

namespace Aromas.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}