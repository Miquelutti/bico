using Fatec.Domain.Entities.User;
using System.Threading.Tasks;

namespace Fatec.Domain.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserById(long id);
        public Task<User> GetUserByCPF(string cpf);
    }
}
