using Aromas.App.Interface;
using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Services;

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
    }
}