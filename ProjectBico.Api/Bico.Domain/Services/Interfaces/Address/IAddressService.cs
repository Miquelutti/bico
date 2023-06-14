using System.Collections.Generic;
using System.Threading.Tasks;
using AddressEntity = Fatec.Domain.Entities.Address.Address;

namespace Fatec.Domain.Services.Interfaces.Address
{
    public interface IAddressService
    {
        public Task<bool> UpdateAddress(long id, AddressEntity request);
        public Task<AddressEntity> GetAddressByUserId(long id);
        public Task<AddressEntity> GetAddressById(long id);
        public Task<IEnumerable<AddressEntity>> GetAllAddresses();
    }
}
