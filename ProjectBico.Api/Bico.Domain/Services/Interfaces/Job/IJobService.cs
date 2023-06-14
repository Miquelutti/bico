using System.Collections.Generic;
using System.Threading.Tasks;
using JobEntity = Fatec.Domain.Entities.Job.Job;

namespace Fatec.Domain.Services.Interfaces.Job
{
    public interface IJobService
    {
        public Task<bool> CreateJob(JobEntity request);
        public Task<IEnumerable<JobEntity>> GetJobs();
        public Task<JobEntity> GetJobById(long jobId);
        public Task<bool> ChangeActivation(long id, int activationId);
    }
}
