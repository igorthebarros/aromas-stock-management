using Aromas.Domain.Entities;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Aromas.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        public async Task<User> CheckUser(string email, string password)
        {
            return Db.Set<User>().Where(e => e.Email == email && e.Password == password).FirstOrDefault();
        }
    }
}