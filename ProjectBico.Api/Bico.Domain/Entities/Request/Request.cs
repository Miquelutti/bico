using System;
using UserEntity = Fatec.Domain.Entities.User.User;
using RequestStatusEntity = Fatec.Domain.Entities.RequestStatus.RequestStatus;
using JobEntity = Fatec.Domain.Entities.Job.Job;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;

namespace Fatec.Domain.Entities.Request
{
    public class Request : Entity
    {
        public UserEntity ContractingUser { get; set; }
        public virtual long ContractingUserId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? RejectionDate { get; set; }
        public string Description { get; set; }
        public JobEntity Job { get; set; }
        public virtual long JobId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public RequestStatusEntity RequestStatus { get; set; }
        public virtual long RequestStatusId { get; set; }
        public ContractEntity Contract { get; set; }
        public virtual long ContractId { get; set; }
    }
}
