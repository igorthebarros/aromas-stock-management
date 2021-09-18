using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;

namespace Aromas.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}