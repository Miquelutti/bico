using Fatec.Domain.Exceptions;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces.Job;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobEntity = Fatec.Domain.Entities.Job.Job;

namespace Fatec.Domain.Services.Job
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUnitOfWork _unitOfWork;

        private const int ACTIVE = 1;

        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> CreateJob(JobEntity request)
        {
            request.IsActive = ACTIVE;

            _jobRepository.Add(request);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobEntity>> GetJobs()
        {
            return await _jobRepository.GetAllAsync();
        }

        public async Task<JobEntity> GetJobById(long id)
        {
            return await _jobRepository.FindById(id);
        }

        public async Task<bool> ChangeActivation(long id, int activationId) 
        {
            var job = await _jobRepository.FindById(id);
            
            if (job == null)
                throw new NotFoundException("JOB NOT FOUND!");

            job.ChangeActivation(activationId);

            _jobRepository.Update(job);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
