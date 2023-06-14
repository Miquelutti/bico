using Fatec.Domain.Enums;
using System.Collections.Generic;
using RequestEntity = Fatec.Domain.Entities.Request.Request;

namespace Fatec.Domain.Entities.RequestStatus
{
    public class RequestStatus : Entity
    {
        public string Description { get; set; }
        public ICollection<RequestEntity> Requests { get; set; }

        public static List<RequestStatus> GenerateSeed()
        {
            return new List<RequestStatus>
            {
                new RequestStatus{ Id = (int) RequestStatusEnum.New, Description = nameof(RequestStatusEnum.New) },
                new RequestStatus{ Id = (int) RequestStatusEnum.Rejected, Description = nameof(RequestStatusEnum.Rejected) },
                new RequestStatus{ Id = (int) RequestStatusEnum.Approved, Description = nameof(RequestStatusEnum.Approved) },
                new RequestStatus{ Id = (int) RequestStatusEnum.Cancelled, Description = nameof(RequestStatusEnum.Cancelled) }
            };
        }
    }
}
