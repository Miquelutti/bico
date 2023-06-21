using Bico.Domain.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserEntity = Fatec.Domain.Entities.User.User;

namespace Fatec.Domain.Services.Interfaces.User
{
    public interface IUserService
    {
        public Task<UserEntity> Authenticate(AuthenticateRequest model);
        public Task<IEnumerable<UserEntity>> GetAllUsers();
        public Task<UserEntity> GetUserById(long userId);
        public Task<UserEntity> GetUserByEmail(string email);
        public Task<bool> CreateUser(UserEntity user);
        public Task<bool> UpdateUser(long id, UserEntity user);
        public Task<bool> DeleteUser(long id);
    }
}
