using Aromas.Domain.Entities;
using System.Threading.Tasks;

namespace Aromas.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> CheckUser(string email, string password);
    }
}