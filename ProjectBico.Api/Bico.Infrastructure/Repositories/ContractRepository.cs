using Fatec.Domain.Entities.Contract;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Infrastructure.Context;
using System;

namespace Fatec.Infrastructure.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        private readonly BicoContext _context;

        public ContractRepository(BicoContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
