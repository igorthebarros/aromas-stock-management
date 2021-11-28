using Aromas.Domain.Entities;
using System.Threading.Tasks;

namespace Aromas.App.Interface
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        Task<User> CheckUser(string email, string password);
    }
}