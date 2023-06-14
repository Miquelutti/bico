using Fatec.Domain.Entities.Address;
using System.Threading.Tasks;

namespace Fatec.Domain.Repositories.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<Address> GetAddressById(long id);
        public Task<Address> GetAddressByUserId(long userId);
    }
}
