using Fatec.Domain.Enums;
using System.Collections.Generic;
using JobEntity = Fatec.Domain.Entities.Job.Job;

namespace Fatec.Domain.Entities.JobCategory
{
    public class JobCategory : Entity
    {
        public string Description { get; set; }
        public ICollection<JobEntity> Jobs { get; set; }

        public static List<JobCategory> GenerateSeed()
        {
            return new List<JobCategory>
            {
                new JobCategory{Id = (int)JobCategoryEnum.Construction, Description = nameof(JobCategoryEnum.Construction)},
                new JobCategory{Id = (int)JobCategoryEnum.Domestic, Description = nameof(JobCategoryEnum.Domestic)},
                new JobCategory{Id = (int)JobCategoryEnum.Eletric, Description = nameof(JobCategoryEnum.Eletric)},
                new JobCategory{Id = (int)JobCategoryEnum.Foods, Description = nameof(JobCategoryEnum.Foods)},
                new JobCategory{Id = (int)JobCategoryEnum.GeneralMaintenance, Description = nameof(JobCategoryEnum.GeneralMaintenance)},
                new JobCategory{Id = (int)JobCategoryEnum.InformationTechnology, Description = nameof(JobCategoryEnum.InformationTechnology)},
                new JobCategory{Id = (int)JobCategoryEnum.Logistics, Description = nameof(JobCategoryEnum.Logistics)},
                new JobCategory{Id = (int)JobCategoryEnum.Management, Description = nameof(JobCategoryEnum.Management)},
                new JobCategory{Id = (int)JobCategoryEnum.Market, Description = nameof(JobCategoryEnum.Market)},
                new JobCategory{Id = (int)JobCategoryEnum.Medicine, Description = nameof(JobCategoryEnum.Medicine)},
                new JobCategory{Id = (int)JobCategoryEnum.Other, Description = nameof(JobCategoryEnum.Other)},
                new JobCategory{Id = (int)JobCategoryEnum.Pharmacy, Description = nameof(JobCategoryEnum.Pharmacy)},
                new JobCategory{Id = (int)JobCategoryEnum.Plumbing, Description = nameof(JobCategoryEnum.Plumbing)},
            };
        }
    }
}
