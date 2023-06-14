using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserEntity = Fatec.Domain.Entities.User.User;

namespace Fatec.Domain.Services.Interfaces.User
{
    public interface IUserService
    {
        public Task<IEnumerable<UserEntity>> GetAllUsers();
        public Task<UserEntity> GetUserById(long userId);
        public Task<bool> CreateUser(UserEntity user);
        public Task<bool> UpdateUser(long id, UserEntity user);
        public Task<bool> DeleteUser(long id);
    }
}
