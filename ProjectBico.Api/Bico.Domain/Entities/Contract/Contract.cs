using System;
using JobEntity = Fatec.Domain.Entities.Job.Job;
using UserEntity = Fatec.Domain.Entities.User.User;
using RequestEntity = Fatec.Domain.Entities.Request.Request;
using ContractStatusEntity = Fatec.Domain.Entities.ContractStatus.ContractStatus;

namespace Fatec.Domain.Entities.Contract
{
    public class Contract : Entity
    {
        public RequestEntity Request { get; set; }
        public virtual long RequestId { get; set; }
        public UserEntity ContractingUser { get; set; }
        public virtual long ContractingUserId { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public JobEntity Job { get; set; }
        public virtual long JobId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalDays { get; set; }
        public ContractStatusEntity ContractStatus { get; set; }
        public virtual long ContractStatusId { get; set; }
        public int? Evaluation { get; set; }
    }
}
