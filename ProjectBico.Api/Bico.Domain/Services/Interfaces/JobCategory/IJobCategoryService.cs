using System.Collections.Generic;
using System.Threading.Tasks;
using JobCategoryEntity = Fatec.Domain.Entities.JobCategory.JobCategory;

namespace Fatec.Domain.Services.Interfaces.JobCategory
{
    public interface IJobCategoryService
    {
        public Task<IEnumerable<JobCategoryEntity>> GetJobsCategories();
    }
}
