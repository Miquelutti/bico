using Fatec.Domain.Exceptions;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddressEntity = Fatec.Domain.Entities.Address.Address;

namespace Fatec.Domain.Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<AddressEntity> GetAddressById(long id)
        {
            return await _addressRepository.GetAddressById(id);
        }

        public async Task<AddressEntity> GetAddressByUserId(long userId)
        {
            return await _addressRepository.GetAddressByUserId(userId);
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAddresses()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<bool> UpdateAddress(long id, AddressEntity request)
        {
            AddressEntity address = await _addressRepository.GetAddressById(id);

            if (address == null)
                throw new AddressDoesntExistsException("ADDRESS DOESNT EXIST!");
            
            address.Update(request);

            _addressRepository.Update(address);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}