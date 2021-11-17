using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Aromas.App.Services
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }

        public async Task<User> CheckUser(string email, string password)
        {
            return await _userService.CheckUser(email, password);
        }
    }
}