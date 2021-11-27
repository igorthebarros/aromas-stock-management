using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.App.Services
{
    public class TokenAppService : ITokenAppService
    {
        private readonly ITokenService _tokenService;

        public TokenAppService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public string GenerateToken(User user)
        {
            return _tokenService.GenerateToken(user);
        }
    }
}