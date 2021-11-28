using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;
using System.Threading.Tasks;

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

        public async Task<User> CheckUser(string email, string password)
        {
            return await _userRepository.CheckUser(email, password);
        }
    }
}