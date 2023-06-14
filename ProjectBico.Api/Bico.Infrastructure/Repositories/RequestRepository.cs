using Fatec.Domain.Entities.Request;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private readonly BicoContext _context;

        private const int REQUEST_STATUS_NEW = 1;

        public RequestRepository(BicoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<Request> FindById(long id)
        {
            return await DbSet
                .Where(x => x.Id == id)
                .Include(x => x.ContractingUser).ThenInclude(x => x.Address)
                .Include(x => x.Job)
                .ThenInclude(x => x.Provider).ThenInclude(x => x.Address)
                .FirstAsync();
        }

        public override async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await DbSet.Where(x => x.RequestStatusId == REQUEST_STATUS_NEW)
                .Include(x => x.ContractingUser)
                .Include(x => x.Job)
                .ThenInclude(x => x.Provider)
                .ToListAsync();
        }
    }
}
