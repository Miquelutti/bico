using Fatec.Domain.Entities.Address;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly BicoContext _context;

        public AddressRepository(BicoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Address> GetAddressById(long id)
        {
            return await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Address> GetAddressByUserId(long userId)
        {
            return await DbSet.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}