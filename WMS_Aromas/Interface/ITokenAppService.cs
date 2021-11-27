using Aromas.Domain.Entities;

namespace Aromas.App.Interface
{
    public interface ITokenAppService
    {
        public string GenerateToken(User user);
    }
}