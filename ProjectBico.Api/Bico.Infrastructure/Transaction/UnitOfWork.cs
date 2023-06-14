using Fatec.Domain.Repositories.Transaction;
using Fatec.Infrastructure.Context;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BicoContext _context;

        public UnitOfWork(BicoContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
