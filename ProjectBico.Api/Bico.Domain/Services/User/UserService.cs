using Fatec.Domain.Entities;
using Fatec.Domain.Exceptions;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserEntity = Fatec.Domain.Entities.User.User;

namespace Fatec.Domain.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        { 
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UserEntity> GetUserById(long userId)
        {
            return await _userRepository.FindById(userId);
        }

        public async Task<bool> CreateUser(UserEntity user) 
        {
            var userVerified = await _userRepository.GetUserByCPF(user.CPF);

            if (userVerified != null) 
                throw new UserException("USER ALREADY EXISTS!");

            _userRepository.Add(user);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<bool> UpdateUser(long id, UserEntity request)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null)
                throw new UserException("USER DOESN'T EXIST!");

            user.Update(request);

            _userRepository.Update(user);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(long id)
        {
            var user = await _userRepository.FindById(id);
            
            if (user == null)
                throw new UserException("USER DOESN'T EXIST!");

            _userRepository.Delete(user);

            return await _unitOfWork.SaveChangesAsync();
        }

    }
}
