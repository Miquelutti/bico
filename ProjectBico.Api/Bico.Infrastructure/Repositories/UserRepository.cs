using Fatec.Domain.Entities.User;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BicoContext _context;

        public UserRepository(BicoContext context): base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserByCPF(string cpf) 
        {
            return await DbSet.Where(x => x.CPF == cpf).FirstOrDefaultAsync();
        }

        public override async Task<User> FindById(long id)
        {
            return await DbSet
                .Where(x => x.Id == id)
                .Include(x => x.Address)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(long id)
        {
            return await DbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
