using Fatec.Domain.Entities.JobCategory;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Infrastructure.Repositories
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        private readonly BicoContext _context;

        public JobCategoryRepository(BicoContext context) : base(context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public override async Task<IEnumerable<JobCategory>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
