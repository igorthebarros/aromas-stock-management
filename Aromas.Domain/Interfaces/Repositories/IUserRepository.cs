using Aromas.Domain.Entities;
using System.Threading.Tasks;

namespace Aromas.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> CheckUser(string email, string password);
    }
}