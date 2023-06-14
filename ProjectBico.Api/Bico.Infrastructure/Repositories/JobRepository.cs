using Fatec.Domain.Entities.Job;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly BicoContext _context;

        private const int USER_INEXISTENT = 0;

        public JobRepository(BicoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<Job>> GetAllAsync() 
        {
            return await DbSet
                .Where(x => x.ProviderId != USER_INEXISTENT)
                .ToListAsync();
        }

        public override async Task<Job> FindById(long id) 
        {
            return await DbSet
                .Where(x => x.Id == id)
                .Include(x => x.Provider)
                .FirstOrDefaultAsync();
        }
    }
}
