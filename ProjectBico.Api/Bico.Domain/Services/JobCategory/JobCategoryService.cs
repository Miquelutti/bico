using Fatec.Domain.Repositories.Interfaces;
using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces.JobCategory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobCategoryEntity = Fatec.Domain.Entities.JobCategory.JobCategory;

namespace Fatec.Domain.Services.JobCategory
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository, IUnitOfWork unitOfWork) 
        {
            _jobCategoryRepository = jobCategoryRepository ?? throw new ArgumentNullException(nameof(jobCategoryRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<JobCategoryEntity>> GetJobsCategories() 
        {
            return await _jobCategoryRepository.GetAllAsync();
        }
    }
}
