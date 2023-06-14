using Fatec.Domain.Enums;
using System.Collections.Generic;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;

namespace Fatec.Domain.Entities.ContractStatus
{
    public class ContractStatus : Entity
    {
        public string Description { get; set; }
        public ICollection<ContractEntity> Contracts { get; set; }

        public static List<ContractStatus> GenerateSeed()
        {
            return new List<ContractStatus>
            {
                new ContractStatus { Id = (int) ContractStatusEnum.InProgress, Description = nameof(ContractStatusEnum.InProgress) },
                new ContractStatus { Id = (int) ContractStatusEnum.Concluded, Description = nameof(ContractStatusEnum.Concluded) },
                new ContractStatus { Id = (int) ContractStatusEnum.Cancelled, Description = nameof(ContractStatusEnum.Cancelled) }
            };
        }
    }
}
